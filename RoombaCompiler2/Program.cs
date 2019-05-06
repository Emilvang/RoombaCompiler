using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using RoombaCompiler2.SemanticAnalysis;
using RoombaCompiler2.SemanticAnalysis.Utils;
using System;

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

            var sl = new SymbolListener();

            var listener = new ScopeListener();

            var ParseTreeWalker = new ParseTreeWalker();

            ParseTreeWalker.Walk(sl, tree);

            sl.SymbolTable.ResetTable();

            var typeChecker = new TypeChecker(sl.SymbolTable, sl.DeclaredMethods.ToReadOnlyDictionary());

            typeChecker.Visit(tree);
            //ParseTreeWalker.Walk(listener, tree);

            MainScopeClass.Scopes = listener.Scopes;

            var TypeListener = new TypeListenerEx();

            ParseTreeWalker.Walk(TypeListener, tree);


            
            /*
            var visitor = new PrintVisitor();

            
            
            visitor.VisitProgram(tree);
            Console.WriteLine("Basic visitor done!");
            
            var typeVisitor = new TypeCheckerVisitor();

            typeVisitor.VisitProgram(tree);
            Console.WriteLine("Typechecker visitor done!");
            */
            
            Console.WriteLine("Checking scopes:");

            foreach (var Scope in listener.Scopes)
            {
                Console.WriteLine("Scope start:");
                foreach (var element in Scope.SymbolTable)
                {
                    Console.WriteLine(element.Key + " " + element.Value);
                }

            }

            var codeGen = new CodeGenListener();
            ParseTreeWalker.Walk(codeGen, tree);
            
            System.IO.File.WriteAllText(@"pythonScript.txt", codeGen.GeneratedCode);
            Console.WriteLine(codeGen.GeneratedCode);
            
            Console.ReadLine();
        }
    }
}
