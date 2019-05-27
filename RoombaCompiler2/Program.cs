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

            var ParseTreeWalker = new ParseTreeWalker();

            ParseTreeWalker.Walk(sl, tree);

            if (sl.Errors.Any())
            {
                Console.WriteLine("Compilation has been stoped due to errors in the scope checking phaes");
                Console.WriteLine("Printing scope errors:");
                sl.PrintErrors();
                Console.ReadLine();
                return;
            }

            sl.SymbolTable.ResetTable();

            var typeChecker = new TypeChecker(sl.SymbolTable, sl.DeclaredMethods.ToReadOnlyDictionary());

            typeChecker.Visit(tree);

            if (typeChecker.Errors.Any())
            {
                Console.WriteLine("Compilation has been stoped due to errors in the scope checking phaes");
                Console.WriteLine("Printing type errors:");
                typeChecker.PrintErrors();
                Console.ReadLine();
                return;
            }

            var onErrorMethodExactName = sl.DeclaredMethods.FirstOrDefault(x =>
                x.Key.Equals("onerror", StringComparison.InvariantCultureIgnoreCase) &&
                x.Value.ReturnType == SemanticAnalysis.Models.EValueType.Void &&
                !x.Value.Parameters.Any()).Key;

            var codeGen = new CodeGenListener(onErrorMethodExactName);
            ParseTreeWalker.Walk(codeGen, tree);
            
            //Added local path here for easier testing
            System.IO.File.WriteAllText(@"pythonScript.py", codeGen.GeneratedCode);
            //System.IO.File.WriteAllText(@"C:\Users\grave\pyCreate2-master\pythonScript.py", codeGen.GeneratedCode);
            Console.WriteLine("Compilation finished successfully");
            Console.WriteLine(codeGen.GeneratedCode);
            Console.ReadLine();
        }
    }
}
