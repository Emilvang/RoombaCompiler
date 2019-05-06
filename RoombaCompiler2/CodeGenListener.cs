using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime.Misc;

/* Checklist:
 * Iterative statements - CHECK
 * Variable declarations - CHECK
 * Built-in functions - NO
 * Other functions - CHECK
 * Conditional statements - CHECK
 * Program setup - CHECK?
 * 
 */


namespace RoombaCompiler2
{
    class CodeGenListener : GrammarBaseListener
    {
        public string GeneratedCode { get; set; }
        public string prefix = "\r\n";
        
        public CodeGenListener()
        {
            GeneratedCode = "";
        }

        public override void EnterProgram([NotNull] GrammarParser.ProgramContext context)
        {
            GeneratedCode += "class Run:\r\n\tdef __init__(self,factory):\r\n\t\"\"\"Constructor.\r\n" +
                    "Args:\r\n\tfactory (factory.FactoryCreate)\r\n\t\"\"\"\r\nself.create = factory.create_create()\r\nself.time = factory.create_time_helper()\r\n" +
                    "def run(self):\r\n\tself.create.start()\r\n\tself.create.safe()\r\n";
            base.EnterProgram(context);
        }

        public override void EnterFunc_stmt([NotNull] GrammarParser.Func_stmtContext context)
        {           
            
           CreateDefaultFunction(context);
                

            base.EnterFunc_stmt(context);
        }
        
        private void CreateDefaultFunction(GrammarParser.Func_stmtContext context)
        {
            GeneratedCode += prefix + "def " + context.GetChild(1) + "(";
            prefix += "\t";
            //3 because here the arguments begin.
            int count2 = 3;
            //Probably needs an escape or exception thrown somehow if the programmer makes an error. What happens if the programmer forgets a comma?
            //Cant handle no arguments.
            while (true)
            {
                try
                {
                    var variableName = context.GetChild(count2).GetChild(1).GetText();
                    GeneratedCode += $"{variableName}";
                    if (context.GetChild(count2 + 1).GetText() != ")")
                    {
                        GeneratedCode += ", ";
                        count2 += 2;
                    }
                    else
                    {
                        GeneratedCode += $"):";
                        break;
                    }
                }
                catch
                {
                    GeneratedCode += $"):";
                    break;
                }

            }

        }

        public override void ExitFunc_stmt([NotNull] GrammarParser.Func_stmtContext context)
        {
            prefix = RemovePrefix(prefix, "\t");            
            
            base.ExitFunc_stmt(context);
        }
        public override void EnterFunc_expr([NotNull] GrammarParser.Func_exprContext context)
        {            
            GeneratedCode += prefix + context.GetText();
            base.EnterFunc_expr(context);
        }

        public override void ExitFunc_expr([NotNull] GrammarParser.Func_exprContext context)
        {
            //Do nothing
            base.ExitFunc_expr(context);
        }

        public override void EnterIter_stmt([NotNull] GrammarParser.Iter_stmtContext context)
        {
            
            switch (context.GetChild(0).GetText())
            {
                case "for":                    
                                      
                    //Get the inital and end value of i
                    int Start = Convert.ToInt32(context.GetChild(3).GetText());
                    int End = Convert.ToInt32(context.GetChild(5).GetText());                    
                    GeneratedCode += $"{prefix}for i in range({Start},{End}):";
                    prefix += "\t";
                    break;
                case "while":                   
                    string expression = context.GetChild(1).GetText();
                    GeneratedCode += $"{prefix}while {expression}:";
                    prefix += "\t";
                    break;
                default:
                    Console.WriteLine("Error when generating iterative statement code");
                    break;

            }
            base.EnterIter_stmt(context);
        }

        public override void ExitIter_stmt([NotNull] GrammarParser.Iter_stmtContext context)
        {
            prefix = RemovePrefix(prefix, "\t");
            base.ExitIter_stmt(context);
        }

        public override void EnterVar_decl([NotNull] GrammarParser.Var_declContext context)
        {
            
            string variableName = context.GetChild(1).GetText();
            string expression = context.GetChild(3).GetText();

            string stringToAdd = $"{variableName} = {expression}";

            GeneratedCode += prefix + stringToAdd;

            base.EnterVar_decl(context);
        }

        public override void ExitVar_decl([NotNull] GrammarParser.Var_declContext context)
        {
            //Do nothing?
            base.ExitVar_decl(context);
        }
       
        public override void EnterVar_stmt([NotNull] GrammarParser.Var_stmtContext context)
        {
            
            GeneratedCode += prefix + context.GetText();
            base.EnterVar_stmt(context);
        }

        public override void EnterCond_stmt([NotNull] GrammarParser.Cond_stmtContext context)
        {
            //Do nothing?      

            base.EnterCond_stmt(context);
        }

        public override void ExitCond_stmt([NotNull] GrammarParser.Cond_stmtContext context)
        {
            //prefix = RemovePrefix(prefix, "\t");
            base.ExitCond_stmt(context);
        }

        public override void EnterIf_stmt([NotNull] GrammarParser.If_stmtContext context)
        {

            string stringToAdd = $"if {context.GetChild(1).GetText()}:";            
            GeneratedCode += prefix + stringToAdd;
            prefix += "\t";

            base.EnterIf_stmt(context);
        }
        public override void ExitIf_stmt([NotNull] GrammarParser.If_stmtContext context)
        {
            prefix = RemovePrefix(prefix, "\t");
            base.ExitIf_stmt(context);
        }
        public override void EnterElseif_stmt([NotNull] GrammarParser.Elseif_stmtContext context)
        {
            string stringToAdd = $"elif {context.GetChild(1).GetText()}:";
            GeneratedCode += prefix + stringToAdd;
            prefix += "\t";
            base.EnterElseif_stmt(context);
        }
        public override void ExitElseif_stmt([NotNull] GrammarParser.Elseif_stmtContext context)
        {
            prefix = RemovePrefix(prefix, "\t");
            base.ExitElseif_stmt(context);
        }
        public override void EnterElse_stmt([NotNull] GrammarParser.Else_stmtContext context)
        {
            string stringToAdd = $"else:";
            GeneratedCode += prefix + stringToAdd;
            prefix += "\t";
            base.EnterElse_stmt(context);
        }
        public override void ExitElse_stmt([NotNull] GrammarParser.Else_stmtContext context)
        {
            prefix = RemovePrefix(prefix, "\t");
            base.ExitElse_stmt(context);
        }

        private string RemovePrefix(string sourceString, string removeString)
        {
            int index = sourceString.IndexOf(removeString);
            string cleanPath = (index < 0)
                ? sourceString
                : sourceString.Remove(index, removeString.Length);

            return cleanPath;

        }

    }
}
