using System;
using System.Collections.Generic;
using System.Text;

namespace CLCompiler.Grammar.Tokens
{
    public class Token
    {
        public TokenType Type { get; set; }
        public string Value { get; set; }
        public ICollection<Token> SubTokens { get; set; } = new List<Token>();
    }
}
