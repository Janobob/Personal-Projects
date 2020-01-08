using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using CLCompiler.Grammar.Tokens;

namespace CLCompiler.Grammar
{
    public class Lexer
    {
        // Store found token in a list
        public ICollection<Token> Tokens = new List<Token>();

        // Store content to write
        protected string Content;
        // Tokens for the first tokenization
        protected IEnumerable<TokenDefinition> TopTokenDefinitions = new List<TokenDefinition>
        {
            new TokenDefinition("<.[^>]*>", TokenType.Html),
            new TokenDefinition("{%.*%}", TokenType.Statement),
            new TokenDefinition("{{.*}}", TokenType.Output),
            new TokenDefinition(@"/\*([^*]|[\r\n])*\*/", TokenType.Comment)
        };
        // Tokens for the actual programming detection
        protected IEnumerable<TokenDefinition> StatementDefinitions = new List<TokenDefinition>
        {
            new TokenDefinition("var", TokenType.Keyword),
            new TokenDefinition(@"[=]|[+]|[-]|[\\]|[*]", TokenType.Operator),
            new TokenDefinition(@"[\(]|[\)]|[\[]|[\]]", TokenType.Punctuation),
            new TokenDefinition("\".[^\"]*\"", TokenType.StringIdentifier),
            new TokenDefinition("[0-9]+", TokenType.IntegerIdentifier),
            new TokenDefinition("[a-zA-Z]*", TokenType.Identifier)
        };

        // Lex the text
        public void Lex(string value)
        {
            Content = value;
            DetectTopLevelTokens();

            PrepareStatementTokens();
            PrepareOutputStatements();

            ConvertHtmlTokensToOutputTokens();

            DetectSubStatementTokens();

            ConvertStringIdentifier();

            // print out tokens found
            PrintTokens();
        }

        public void PrintTokens()
        {
            foreach (var token in Tokens)
            {
                Console.WriteLine(!token.SubTokens.Any() ? $"Type: {token.Type} | Value: {token.Value}" : $"Type: {token.Type}");
                if (!token.SubTokens.Any()) continue;
                foreach(var subtoken in token.SubTokens)
                {
                    Console.WriteLine($"\tType: {subtoken.Type} | Value: {subtoken.Value}");
                }
            }
        }

        // Try to find all valid tokens
        private void DetectTopLevelTokens()
        {
            // remember the last valid token
            var lastFoundIndex = 0;

            for (var i = 0; i < Content.Length; i++)
            {
                // check if the current substring is a valid token
                if (TopTokenDefinitions.Any(x => x.IsMatch(Content.Substring(lastFoundIndex, i - lastFoundIndex))))
                {
                    Tokens.Add(new Token
                    {
                        Type = TopTokenDefinitions.FirstOrDefault(x => x.IsMatch(Content.Substring(lastFoundIndex, i - lastFoundIndex))).Type,
                        Value = Content.Substring(lastFoundIndex, i - lastFoundIndex)
                    });
                    // try to find the next token
                    lastFoundIndex = i;
                }
            }

            // if none token was found, somethind is wrong
            if (!Tokens.Any())
            {
                throw new Exception("No valid Content found!");
            }

            // Remove new lines and tabs from the code
            RemoveNewLinesAndTabs();

            //Remove all comments
            RemoveAllComments();
        }

        private void DetectSubStatementTokens()
        {
            // Go through statements and outputs
            foreach (var topToken in Tokens.Where(x => x.Type == TokenType.Statement || x.Type == TokenType.Output))
            {
                // TODO: Avoid splitting by whitespace - no solution found so far ...
                // Get all tokens
                var texts = topToken.Value.Split(" ").Where(x => x != "").ToList();
                // if no tokens are in the statement go to the next
                if (!texts.Any())
                {
                    continue;
                }

                //find tokens
                topToken.SubTokens = new List<Token>();
                foreach (var text in texts)
                {
                    var found = false;
                    foreach (var definition in StatementDefinitions)
                    {
                        if (definition.IsMatch(text))
                        {
                            topToken.SubTokens.Add(new Token
                            {
                                Type = definition.Type,
                                Value = text
                            });
                            found = true;
                            break;
                        }
                    }
                    // return the invalidtoken if no valid token was found
                    if (!found)
                    {
                        topToken.SubTokens.Add(new Token
                        {
                            Type = TokenType.InvalidToken,
                            Value = text
                        });
                    }
                }
                topToken.Value = null;
            }
        }

        private void RemoveNewLinesAndTabs()
        {
            foreach (var token in Tokens)
            {
                token.Value = token.Value.Replace("\n", string.Empty).Replace("\r", string.Empty).Replace("\t", string.Empty);
            }
        }

        private void RemoveAllComments()
        {
            Tokens = Tokens.Where(x => x.Type != TokenType.Comment).ToList();
        }

        private void PrepareStatementTokens()
        {
            var beforePruncReplace = new Regex("{%[ ]?");
            var endPrunchReplace = new Regex("[ ]?%}");
            foreach (var statement in Tokens.Where(x => x.Type == TokenType.Statement))
            {
                statement.Value = beforePruncReplace.Replace(endPrunchReplace.Replace(statement.Value, ""), "");
            }
        }

        private void PrepareOutputStatements()
        {
            foreach (var statement in Tokens.Where(x => x.Type == TokenType.Output))
            {
                statement.Value = statement.Value[2..^2];
            }
        }

        private void ConvertHtmlTokensToOutputTokens()
        {
            foreach (var token in Tokens.Where(x => x.Type == TokenType.Html))
            {
                token.Type = TokenType.Output;
                token.Value = $"\"{token.Value}\"";
            }
        }

        private void ConvertStringIdentifier()
        {
            foreach (var token in Tokens.SelectMany(x => x.SubTokens.Where(y => y.Type == TokenType.StringIdentifier)))
            {
                token.Value = token.Value[1..^1];
            }
        }
    }
}
