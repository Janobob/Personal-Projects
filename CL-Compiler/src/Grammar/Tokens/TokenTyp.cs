using System;
using System.Collections.Generic;
using System.Text;

namespace CLCompiler.Grammar.Tokens
{
    public enum TokenType
    {
        Statement,
        Output,
        Html,
        Comment,
        Keyword,
        Identifier,
        Operator,
        IntegerIdentifier,
        StringIdentifier,
        InvalidToken,
        Punctuation
    }
}
