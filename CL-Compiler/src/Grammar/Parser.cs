using CLCompiler.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using CLCompiler.Grammar.Expressions;
using CLCompiler.Grammar.Tokens;
using CLCompiler.Grammar.Variables;

namespace CLCompiler.Grammar
{
    public class Parser
    {
        public string CompiledContent = "";

        protected IDictionary<string, Variable> Variables = new Dictionary<string, Variable>();
        protected IEnumerable<Token> Tokens;

        public void Parse(IEnumerable<Token> tokens)
        {
            Tokens = tokens;
            RunCommands(0, Tokens.Count());
        }

        public void RunCommands(int startIndex, int stopIndex)
        {
            var currentToken = Tokens.ElementAt(startIndex);

            if (currentToken.Type == TokenType.Output)
            {
                HandleOutput(currentToken);
            }

            if (currentToken.Type == TokenType.Statement)
            {
                HandleStatement(currentToken);
            }

            if (startIndex + 1 < stopIndex && startIndex + 1 < Tokens.Count())
            {
                RunCommands(startIndex + 1, stopIndex);
            }
        }

        private void HandleOutput(Token token)
        {
            var subtokens = token.SubTokens.ToList();

            // direkt indentifier
            if (subtokens.ElementAt(0).Type == TokenType.StringIdentifier &&
                token.SubTokens.Count == 1 ||
                subtokens.ElementAt(0).Type == TokenType.IntegerIdentifier &&
                token.SubTokens.Count == 1)
            {
                CompiledContent += subtokens.ElementAt(0).Value;
                return;
            }

            // variable identifier
            if (subtokens.ElementAt(0).Type == TokenType.Identifier &&
                token.SubTokens.Count == 1)
            {
                CompiledContent += GetVariable(subtokens.ElementAt(0).Value).Content;
                return;
            }

            // throw Exception when no suitable output is defined (syntax error)
            CompiledContent += new NumericExpression(subtokens, this).Evaluate().Value;
        }

        private void HandleStatement(Token token)
        {
            var subtokens = token.SubTokens.ToList();

            // Assignment
            if (subtokens.ElementAt(0).Type == TokenType.Keyword &&
                subtokens.ElementAt(0).Value.Equals("var", StringComparison.OrdinalIgnoreCase) &&
                subtokens.ElementAt(1).Type == TokenType.Identifier &&
                subtokens.ElementAt(2).Type == TokenType.Operator &&
                subtokens.ElementAt(2).Value.Equals("=", StringComparison.OrdinalIgnoreCase))
            {
                if ((subtokens.ElementAt(3).Type == TokenType.StringIdentifier ||
                     subtokens.ElementAt(3).Type == TokenType.IntegerIdentifier ||
                     subtokens.ElementAt(3).Type == TokenType.Identifier) && subtokens.Count == 4)
                {
                    ProcessAssignment(subtokens.ElementAt(1).Value, subtokens.ElementAt(3));
                    return;
                }
                ProcessAssignment(subtokens.ElementAt(1).Value, new NumericExpression(subtokens.GetRange(3, subtokens.Count - 3), this).Evaluate());
                return;
            }
        }

        private void ProcessAssignment(string variablename, Token value)
        {
            // override existing value
            if (VariableExists(variablename))
            {
                if (value.Type == TokenType.IntegerIdentifier && int.TryParse(value.Value, out var parsedValue))
                {
                    Variables[variablename] = new Variable(parsedValue, typeof(int));
                    return;
                }

                if (value.Type == TokenType.StringIdentifier)
                {
                    Variables[variablename] = new Variable(value.Value, typeof(string));
                    return;
                }

                if (value.Type == TokenType.Identifier)
                {
                    var variable = GetVariable(value.Value);
                    Variables[variablename] = new Variable(variable.Content, variable.Type);
                    return;
                }

                Variables[variablename] = new Variable(value.Value, typeof(object));
                return;
            }

            // write to variable stack
            if (value.Type == TokenType.IntegerIdentifier && int.TryParse(value.Value, out var parsedValueAfter))
            {
                Variables.Add(variablename, new Variable(parsedValueAfter, typeof(int)));
                return;
            }

            if (value.Type == TokenType.StringIdentifier)
            {
                Variables.Add(variablename, new Variable(value.Value, typeof(string)));
                return;
            }

            if (value.Type == TokenType.Identifier)
            {
                var variable = GetVariable(value.Value);
                Variables.Add(variablename, new Variable(variable.Content, variable.Type));
                return;
            }

            Variables.Add(variablename, new Variable(value.Value, typeof(object)));
        }

        public Variable GetVariable(string variablename)
        {
            if (Variables.ContainsKey(variablename))
            {
                return Variables[variablename];
            }

            throw new Exception("Variable is not defined.");
        }

        public bool VariableExists(string variablename)
        {
            return Variables.ContainsKey(variablename);
        }
    }
}
