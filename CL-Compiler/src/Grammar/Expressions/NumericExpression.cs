using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using CLCompiler.Grammar.Tokens;
using CLCompiler.Grammar.Variables;

namespace CLCompiler.Grammar.Expressions
{
    public class NumericExpression
    {
        protected List<Token> Tokens;
        protected Parser Parser;

        public NumericExpression(List<Token> tokens, Parser parser)
        {
            Tokens = tokens;
            Parser = parser;
        }

        public Token Evaluate()
        {
            // Stack for numbers
            var values = new Stack<int>();
            // Stack for Operators
            var operators = new Stack<Token>();

            for (var i = 0; i < Tokens.Count; i++)
            {
                // if the current token is a number, push it to stack for numbers
                if (Tokens[i].Type == TokenType.IntegerIdentifier)
                {
                    values.Push(int.Parse(Tokens[i].Value));
                }

                // Current token is an opening brace, push it to operators
                else if (Tokens[i].Type == TokenType.Punctuation && Tokens[i].Value == "(")
                {
                    operators.Push(Tokens[i]);
                }

                // Closing brace encountered, solve entire brace
                else if (Tokens[i].Type == TokenType.Punctuation && Tokens[i].Value == ")")
                {
                    while (operators.Peek().Value != "(")
                    {
                        values.Push(ApplyOperation(operators.Pop(), values.Pop(), values.Pop()));
                    }

                    operators.Pop();
                }

                // Current token is an operator. 
                else if (Tokens[i].Type == TokenType.Operator)
                {
                    // While top of 'ops' has same or greater precedence to current  
                    // token, which is an operator. Apply operator on top of 'ops'  
                    // to top two elements in values stack  
                    while (operators.Count > 0 && HasPrecedence(Tokens[i], operators.Peek()))
                    {
                        values.Push(ApplyOperation(operators.Pop(), values.Pop(), values.Pop()));
                    }

                    // Push current token to 'ops'. 
                    operators.Push(Tokens[i]);
                }
            }

            // Entire expression has been parsed at this point, apply remaining  
            // ops to remaining values 
            while (operators.Count > 0)
            {
                values.Push(ApplyOperation(operators.Pop(), values.Pop(), values.Pop()));
            }

            // Top of 'values' contains result, return it 
            return new Token
            {
                Value = values.Pop().ToString(),
                Type = TokenType.IntegerIdentifier
            };
        }

        // Returns true if 'op2' has higher or same precedence as 'op1',  
        // otherwise returns false. 
        private bool HasPrecedence(Token op1, Token op2)
        {
            if (op2.Type == TokenType.Punctuation)
            {
                return false;
            }

            return (op1.Value == "*" || op1.Value == "/") && (op2.Value == "+" || op2.Value == "-");
        }

        // A utility method to apply an operator 'op' on operands 'value1'   
        // and 'value2'. Return the result. 
        private int ApplyOperation(Token op, int value1, int value2)
        {
            switch (op.Value)
            {
                case "+":
                    return value1 + value2;
                case "-":
                    return value1 - value2;
                case "*":
                    return value1 * value2;
                case "/":
                    if (value2 == 0)
                    {
                        throw new Exception("Cannot divide by zero");
                    }
                    return value1 / value2;
            }

            return 0;
        }
    }
}
