using System;
using System.Globalization;
using System.Linq;
using System.Text;
using CLCompiler.Grammar;
using CLCompiler.IO;

namespace CLCompiler
{
    public class Compiler
    {
        protected FileManager FileManager;
        protected Lexer Lexer;
        protected Parser Parser;

        protected string Src;
        protected string Output;
        protected string Content;

        public Compiler()
        {
            FileManager = new FileManager();
            Lexer = new Lexer();
            Parser = new Parser();
        }

        public void Compile(string src, string output = null)
        {
            Src = src;
            Output = output;

            BeginCompile();

            Lexer.Lex(Content);
            Parser.Parse(Lexer.Tokens);

            Content = Parser.CompiledContent;

            EndCompile();
        }

        private void BeginCompile()
        {
            // Read Source code from File
            Content = FileManager.ReadContentFromFile(Src);

            // Generate pseudo ouput, if not given
            if (Output == null) Output = @$"../../../Content/Output/{Src.Split("/").Last().Split(".").First()}.html";
        }

        private void EndCompile()
        {
            // Write compiled code to file
            FileManager.WriteContentToFile(Content, Output);
        }
    }
}
