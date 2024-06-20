using Spectre.Console;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class TextEditor
{
    private List<string> _lines;
    private int _cursorX;
    private int _cursorY;
    private bool _running;
    private bool _showConsole;
    private List<string> _consoleMessages;

    public TextEditor()
    {
        _lines = new List<string> { string.Empty };
        _cursorX = 0;
        _cursorY = 0;
        _showConsole = false;
        _running = true;
        _consoleMessages = new List<string> { string.Empty };

    }

    public void Run()
    {
        Console.Clear();


        while (_running)
        {
            Render();
            HandleInput();
        }

        AnsiConsole.Cursor.Show();
        Console.Clear();
        AnsiConsole.MarkupLine("[bold yellow]Éditeur quitté. Contenu final :[/]");
        foreach (var line in _lines)
        {
            Console.WriteLine(line);
        }
    }

    private void Render()
    {
        Console.Clear();
        int editorHeight = _showConsole ? (Console.WindowHeight * 3 / 4) : Console.WindowHeight;
        int consoleHeight = Console.WindowHeight - editorHeight;

        RenderEditor(editorHeight);

        if (_showConsole)
        {
            RenderConsole(consoleHeight);
        }

        Console.SetCursorPosition(_cursorX + 5, _cursorY);
    }

    private void RenderEditor(int height)
    {
        for (int i = 0; i < height && i < _lines.Count; i++)
        {
            var line = _lines[i];
            var lineNumber = (i + 1).ToString().PadLeft(3);
            var highlightedLine = HighlightText(line);

            if (i == _cursorY)
            {
                AnsiConsole.MarkupLine($"[blue]{lineNumber}: {highlightedLine}[/]");
            }
            else
            {
                AnsiConsole.MarkupLine($"{lineNumber}: {highlightedLine}");
            }
        }
    }

    private void RenderConsole(int height)
    {
        var panel = new Panel(string.Join("\n", _consoleMessages))
        {
            Border = BoxBorder.Square,
            BorderStyle = new Style(Color.White),
            Padding = new Padding(1, 1, 1, 1),
            Width = Console.WindowWidth - 2,
            Height = height - 2
        };
        AnsiConsole.Render(panel);
    }

    private string HighlightText(string line)
    {
        // Liste des mots-clés à surligner
        var keywords = new List<string> { "DVAR", "PRT", "RET" };
        var keywordsManip = new List<string> { "MUL", "ADD", "SUB", "DIV" };

        // Remplacer les mots-clés
        foreach (var keyword in keywords)
        {
            var pattern = $@"\b{Regex.Escape(keyword)}\b";
            var replacement = $"[green]{keyword}[/]";
            line = Regex.Replace(line, pattern, replacement);
        }

        foreach (var keyword in keywordsManip)
        {
            var pattern = $@"\b{Regex.Escape(keyword)}\b";
            var replacement = $"[cyan]{keyword}[/]";
            line = Regex.Replace(line, pattern, replacement);
        }

        // Remplacer les textes entre guillemets simples ou doubles
        var quotePattern = @"(['""]).*?\1";
        line = Regex.Replace(line, quotePattern, match => $"[red]{match.Value}[/]");

        var quoteVarPattern = @"(['{{}}]).*?\1";
        line = Regex.Replace(line, quoteVarPattern, match => $"[purple]{match.Value}[/]");


        // Remplacer les nombres (entiers, flottants, décimaux, etc.)
        var numberPattern = @"\b\d+(\.\d+)?\b";
        line = Regex.Replace(line, numberPattern, match => $"[yellow]{match.Value}[/]");

        return line;
    }


    private void HandleInput()
    {
        var key = Console.ReadKey(intercept: true);

        switch (key.Key)
        {
            case ConsoleKey.Q when key.Modifiers == ConsoleModifiers.Control:
                _running = false;
                break;
            case ConsoleKey.S when key.Modifiers == ConsoleModifiers.Control:
                SaveContent();
                break;
            case ConsoleKey.R when key.Modifiers == ConsoleModifiers.Control:
                ToggleConsole();
                break;
            case ConsoleKey.UpArrow:
                if (_cursorY > 0) _cursorY--;
                if (_cursorX > _lines[_cursorY].Length) _cursorX = _lines[_cursorY].Length;
                break;
            case ConsoleKey.DownArrow:
                if (_cursorY < _lines.Count - 1) _cursorY++;
                if (_cursorX > _lines[_cursorY].Length) _cursorX = _lines[_cursorY].Length;
                break;
            case ConsoleKey.LeftArrow:
                if (_cursorX > 0) _cursorX--;
                break;
            case ConsoleKey.RightArrow:
                if (_cursorX < _lines[_cursorY].Length) _cursorX++;
                break;
            case ConsoleKey.Backspace:
                if (_cursorX > 0)
                {
                    _lines[_cursorY] = _lines[_cursorY].Remove(_cursorX - 1, 1);
                    _cursorX--;
                }
                else if (_cursorY > 0)
                {
                    _cursorX = _lines[_cursorY - 1].Length;
                    _lines[_cursorY - 1] += _lines[_cursorY];
                    _lines.RemoveAt(_cursorY);
                    _cursorY--;
                }
                break;
            case ConsoleKey.Enter:
                var newLine = _lines[_cursorY][_cursorX..];
                _lines[_cursorY] = _lines[_cursorY][.._cursorX];
                _lines.Insert(_cursorY + 1, newLine);
                _cursorY++;
                _cursorX = 0;
                break;
            case ConsoleKey.Tab:
                _lines[_cursorY] = _lines[_cursorY].Insert(_cursorX, "  ");
                _cursorX += 2;
                break;
            default:
                if (!char.IsControl(key.KeyChar))
                {
                    _lines[_cursorY] = _lines[_cursorY].Insert(_cursorX, key.KeyChar.ToString());
                    _cursorX++;
                }
                break;
        }
    }
    private void ToggleConsole()
    {
        _showConsole = !_showConsole;
        
    }
    private void SaveContent()
    {
        File.WriteAllLines("output.asmx", _lines);
        AnsiConsole.MarkupLine("[bold green]Fichier sauvegardé sous le nom 'output.txt'[/]");
    }
}
