public class Lexer
{
    private string code;
    private readonly string EMPTY = "";
    private int pos;
    public Lexer(string code)
    {
        this.code = code;
        this.pos = 0;
    }

    public Tokenization getNextToken()
    {
        while (this.pos < this.code?.Length) { 
            char c_char = this.code[this.pos];
            if (char.IsWhiteSpace(c_char))
            {
                this.pos++;
                continue;
            }
            else if (c_char == '\n') {
                this.pos++;
                continue;
            }
            else if(char.IsDigit(c_char))
            {
                int start = this.pos;
                while(this.pos < this.code?.Length && (char.IsDigit(this.code[this.pos]) || this.code[this.pos] == '.'))
                {
                    this.pos++;
                }
                return new Tokenization(Token.NUMBER, this.code?.Substring(start, this.pos - start)!);
            }
            else if (char.IsLetter(c_char))
            {
                int start = this.pos;
                while (this.pos < this.code?.Length && char.IsLetterOrDigit(this.code[this.pos]))
                {
                    this.pos++;
                }
                string w_ident = this.code?.Substring(start, this.pos - start)!;
                if (w_ident == "DVAR") return new Tokenization(Token.DVAR, w_ident);
                else if (w_ident == "PRT") return new Tokenization(Token.OUTPUT, w_ident);
                else if (w_ident == "RET") return new Tokenization(Token.RETURN, w_ident);
                else if (w_ident == "ADD") return new Tokenization(Token.ADD, w_ident);
                else if (w_ident == "SUB") return new Tokenization(Token.SUB, w_ident);
                else if (w_ident == "MUL") return new Tokenization(Token.MUL, w_ident);
                else if (w_ident == "DIV") return new Tokenization(Token.DIV, w_ident);
                else return new Tokenization(Token.IDENT, w_ident);
            }
            else if (c_char == '=')
            {
                this.pos++;
                return new Tokenization(Token.ASSIGN, "=");
            }
            else if (c_char == '"')
            {
                this.pos++;
                int start = this.pos;
                while (this.pos < this.code.Length && this.code[this.pos] != '"') {
                    this.pos++;
                }
                this.pos++;
                return new Tokenization(Token.STRING, this.code.Substring(start, this.pos - start));
            }
        }
        Console.WriteLine("EOF");
        return new Tokenization(Token.EOF, EMPTY);
    }
}
