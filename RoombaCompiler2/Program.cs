using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using RoombaCompiler2.SemanticAnalysis;
using RoombaCompiler2.SemanticAnalysis.Utils;
using System;
using System.Linq;

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

            var onErrorMethodExactName = sl.DeclaredMethods.FirstOrDefault(x =>
                x.Key.Equals("onerror", StringComparison.InvariantCultureIgnoreCase) &&
                x.Value.ReturnType == SemanticAnalysis.Models.EValueType.Void &&
                !x.Value.Parameters.Any()).Key;

            var codeGen = new CodeGenListener(onErrorMethodExactName);
            ParseTreeWalker.Walk(codeGen, tree);


            //Maybe add an if statement that if there were errors, then don't run code gen.
                //Added local path here for easier testing
                System.IO.File.WriteAllText(@"pythonScript.py", codeGen.GeneratedCode);
                System.IO.File.WriteAllText(@"C:\Users\grave\pyCreate2-master\pythonScript.py", codeGen.GeneratedCode);
                Console.WriteLine(codeGen.GeneratedCode);
            
           
            

            Console.ReadLine();
        }
    }
}
