using Antlr4.Runtime;

using Antlr4.Runtime.Tree;
using RoombaCompiler2.TypeChecking;
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
            //Adding translating tools for bools
            MainScopeClass.AddElements();
            var charStream = CharStreams.fromPath("firstProgram.txt");

            var lexer = new GrammarLexer(charStream);

            var tokenStream = new CommonTokenStream(lexer);

            var parser = new GrammarParser(tokenStream)
            {
                BuildParseTree = true
            };

            var tree = parser.program();

            
            
            var visitor = new PrintVisitor();

            visitor.VisitProgram(tree);
            Console.WriteLine("Basic visitor done!");

            var typeVisitor = new TypeCheckerVisitor();

            typeVisitor.VisitProgram(tree);
            Console.WriteLine("Typechecker visitor done!");
            Console.WriteLine("Checking main scope:");
            int scopeCount = 0;
            foreach (var element in MainScopeClass.Scopes)
            {
                Console.WriteLine("Scope : " + scopeCount);
                foreach(var child in element.Value)
                {
                    Console.WriteLine(child);
                }
                scopeCount++;
            }

            Console.ReadLine();
        }
    }
}
