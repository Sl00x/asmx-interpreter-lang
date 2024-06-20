public class Prototype
{
    public Token Identifier { get; set; }
    public string Name { get; set; }
    public string Value { get; set; }

    public Prototype(Token ident, string name, string value)
    {
        this.Identifier = ident;
        this.Name = name;
        this.Value = value;
    }
}