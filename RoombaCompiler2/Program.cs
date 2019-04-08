using Antlr4.Runtime;

using Antlr4.Runtime.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoombaCompiler2
{
    class Program
    {
        static void Main(string[] args)
        {
            var charStream = CharStreams.fromstring("Program { int Horse=2 Test = 55 }");

            var lexer = new GrammarLexer(charStream);

            var tokenStream = new CommonTokenStream(lexer);

            var parser = new GrammarParser(tokenStream);

            parser.BuildParseTree = true;

            var tree = parser.program();

            var visitor = new PrintVisitor();

            visitor.VisitProgram(tree);

            
            Console.WriteLine("Works!");
            Console.ReadLine();
        }
    }
}
