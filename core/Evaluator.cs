
using Spectre.Console;

public class Evaluator
{
    private List<Prototype> prototypes = new List<Prototype>();
    private Dictionary<string, string> vars = new Dictionary<string, string>();
    public Evaluator(List<Prototype> prototypes)
    {
        this.prototypes = prototypes;
    }

    public void eval()
    {
        foreach (var node in prototypes)
        {
            Console.WriteLine($"{node.Name}");
            this.eval_ast(node);
        }
    }

    public void eval_ast(Prototype node)
    {
        Console.WriteLine($"[blue]DEBUG[/]: {this.vars[node.Name]}");
        if (node.Identifier == Token.DVAR)
        {
            this.vars[node.Name] = node.Value;
        }
        else if(node.Identifier == Token.ADD)
        {
            var value = Convert.ToInt32(this.vars[node.Name]);
            this.vars[node.Name] = (value + Convert.ToInt32(node.Value)).ToString();
        }
        else if (node.Identifier == Token.SUB)
        {
            var value = Convert.ToInt32(this.vars[node.Name]);
            this.vars[node.Name] = (value - Convert.ToInt32(node.Value)).ToString();
        }
        else if (node.Identifier == Token.MUL)
        {
            var value = Convert.ToInt32(this.vars[node.Name]);
            this.vars[node.Name] = (value * Convert.ToInt32(node.Value)).ToString();
        }
        else if (node.Identifier == Token.DIV)
        {
            var value = Convert.ToInt32(this.vars[node.Name]);
            var dividBy = Convert.ToInt32(node.Value);
            if (dividBy == 0) throw new Exception("Impossible de diviser par 0"); 
            this.vars[node.Name] = (value / dividBy).ToString();
        }
        else if (node.Identifier == Token.OUTPUT)
        {
            Console.WriteLine($"[blue]DEBUG[/]: {this.vars[node.Name]}");
        }
    }
}