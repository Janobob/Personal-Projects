using System;
using System.Collections.Generic;
using System.Text;

namespace CLCompiler.Grammar.Variables
{
    public class Variable
    {
        public object Content;
        public Type Type;


        public Variable(object content, Type type)
        {
            Content = content;
            Type = type;
        }
    }
}
