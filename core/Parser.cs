using System.Collections.Concurrent;
using System.Runtime.CompilerServices;

public class Parser
{
    private Lexer lexer;
    private Tokenization token;
    public Parser(Lexer lexer)
    {
        this.lexer = lexer;
        this.token = this.lexer.getNextToken();
    }

    private void burn(Token type)
    {
        if (this.token.getType() == type) {
            this.token = this.lexer.getNextToken();
        }
        else
        {
            throw new InvalidOperationException("Difference between current token");
        }
    }

    public List<Prototype> parse()
    {
        List<Prototype> nodes = new List<Prototype>();

        while (this.token.getType() != Token.EOF)
        {
            
            nodes.Add(this.Prototypage());
        }
        return nodes;

    }

    private Prototype Prototypage()
    {
        if(this.token.getType() == Token.DVAR)
        {
            return this.DvarStatement();
        } 
        else if(this.token.getType() == Token.ADD)
        {
            return this.OperandStatement(Token.ADD);
        }
        else if (this.token.getType() == Token.SUB)
        {
            return this.OperandStatement(Token.SUB);
        }
        else if (this.token.getType() == Token.MUL)
        {
            return this.OperandStatement(Token.MUL);
        }
        else if (this.token.getType() == Token.DIV)
        {
            return this.OperandStatement(Token.DIV);
        }
        return new Prototype(Token.EOF, "", "");
    }

    private Prototype DvarStatement() {
        this.burn(Token.DVAR);
        string dvar = this.token.getValue();
        this.burn(Token.IDENT);
        this.burn(Token.ASSIGN);
        string value = this.token.getValue();
        return new Prototype(Token.DVAR, dvar, value);
    }

    private Prototype OperandStatement(Token type)
    {
        this.burn(type);
        string dvar = this.token.getValue();
        this.burn(Token.IDENT);
        this.burn(Token.ASSIGN);
        string value = this.token.getValue();
        return new Prototype(type, dvar, value);
    }

    private Prototype Output()
    {
        this.burn(Token.DVAR);
        string dvar = this.token.getValue();
        this.burn(Token.IDENT);
        this.burn(Token.ASSIGN);
        string value = this.token.getValue();
        return new Prototype(Token.DVAR, dvar, value);
    }
}
