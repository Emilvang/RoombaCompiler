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
            var charStream = CharStreams.fromPath("simpleProgram.txt");

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
            Console.WriteLine("Printing scope errors:");
            sl.PrintErrors();
            sl.SymbolTable.ResetTable();
            


            var typeChecker = new TypeChecker(sl.SymbolTable, sl.DeclaredMethods.ToReadOnlyDictionary());

            typeChecker.Visit(tree);
            Console.WriteLine("Printing type errors:");
            typeChecker.PrintErrors();
            
            
            

            var codeGen = new CodeGenListener();
            ParseTreeWalker.Walk(codeGen, tree);
            //Added local path here for easier testing
            System.IO.File.WriteAllText(@"C:\Users\grave\pyCreate2-master\pythonScript.py", codeGen.GeneratedCode);
            Console.WriteLine(codeGen.GeneratedCode);
            
            //Console.ReadLine();
        }
    }
}
