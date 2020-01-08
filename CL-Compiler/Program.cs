using CLCompiler.IO;
using System;
using System.IO;

namespace CLCompiler
{
    public class Program
    {
        public static void Main(string[] args)
        {
            new Compiler().Compile(@"../../../Content/source/main.cl");
        }
    }
}
