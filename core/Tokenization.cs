using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Tokenization
{
    private Token type;
    private String value;

    public Tokenization(Token type, string value)    {
        this.type = type;
        this.value = value;
    }

    public Token getType() { return this.type; }
    public String getValue() { return this.value; }

}

