using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CLCompiler.Grammar.Tokens
{
    public class TokenDefinition
    {
        public TokenType Type;

        protected Regex Regex;

        public TokenDefinition(string expression, TokenType type)
        {
            Regex = new Regex(expression);
            Type = type;
        }

        public bool IsMatch(string value)
        {
            return Regex.IsMatch(value);
        }
    }
}
