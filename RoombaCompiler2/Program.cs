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
            var charStream = CharStreams.fromPath("firstProgram.txt");

            var lexer = new GrammarLexer(charStream);

            var tokenStream = new CommonTokenStream(lexer);

            var parser = new GrammarParser(tokenStream)
            {
                BuildParseTree = true
            };

            var tree = parser.program();


            var listener = new ScopeListener();

            var ParseTreeWalker = new ParseTreeWalker();

            ParseTreeWalker.Walk(listener, tree);

            MainScopeClass.Scopes = listener.Scopes;

            

            var visitor = new PrintVisitor();

            
            
            //visitor.VisitProgram(tree);
            Console.WriteLine("Basic visitor done!");
            
            var typeVisitor = new TypeCheckerVisitor();

            //typeVisitor.VisitProgram(tree);
            Console.WriteLine("Typechecker visitor done!");

            
            Console.WriteLine("Checking scopes:");

            foreach (var Scope in listener.Scopes)
            {
                Console.WriteLine("Scope start:");
                foreach (var element in Scope.SymbolTable)
                {
                    Console.WriteLine(element);
                }

            }
            /*
            var codeGen = new CodeGenVisitor();
            codeGen.VisitProgram(tree);
            System.IO.File.WriteAllText(@"C:\\Uni\\roombascript.txt", codeGen.GeneratedCode);
            Console.WriteLine(codeGen.GeneratedCode);
            */
            Console.ReadLine();
        }
    }
}
