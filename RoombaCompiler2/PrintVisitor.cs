using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime.Misc;
using System.IO;


namespace RoombaCompiler2
{
    public class PrintVisitor : GrammarBaseVisitor<bool>
    {
        //Prefix can be used for indented to the correct premise, but needs way to check if out of for/while loop and indent back. Maybe an endloop grammar?
        //Cant figure it out.
        string prefix = "\r\n\t";
        string path = @"pythonScript.py";
        public override bool VisitProgram([NotNull] GrammarParser.ProgramContext context)
        {
            Console.WriteLine("Program");

            if (new FileInfo(path).Length != 0)
            {
                File.WriteAllText(path, String.Empty);
            }
            using (StreamWriter sw = File.AppendText(path))
            {              

                sw.Write("class Run:\r\n\tdef __init__(self,factory):\r\n\t\"\"\"Constructor.\r\n" +
                    "Args:\r\n\tfactory (factory.FactoryCreate)\r\n\t\"\"\"\r\nself.create = factory.create_create()\r\nself.time = factory.create_time_helper()\r\n" +
                    "def run(self):\r\n\tself.create.start()\r\n\tself.create.safe()\r\n\t");
            }


            return base.VisitProgram(context);
        }

        public override bool VisitCond_stmt([NotNull] GrammarParser.Cond_stmtContext context)
        {
            Console.WriteLine("Conditional statement");
            return base.VisitCond_stmt(context);
        }
        public override bool VisitStmts([NotNull] GrammarParser.StmtsContext context)
        {
            Console.WriteLine("Statements");         


            return base.VisitStmts(context);
        }

        public override bool VisitFunc_stmt([NotNull] GrammarParser.Func_stmtContext context)
        {
            Console.WriteLine("Function statement");
                          

            return base.VisitFunc_stmt(context);
        }

        public override bool VisitIter_stmt([NotNull] GrammarParser.Iter_stmtContext context)
        {
            Console.WriteLine("Iterative statement");
            
            switch (context.GetChild(0).GetText())
            {
                case "for":                                        

                    //Get the inital and end value of i
                    int Start = Convert.ToInt32(context.GetChild(3).GetText());
                    int End = Convert.ToInt32(context.GetChild(5).GetText());
                    prefix += "\t";
                    using (StreamWriter sw = File.AppendText(path))
                    {
                        sw.Write($"for i in range({End}):{prefix}");
                    }    
                        break;
                case "while":
                    //To do
                    break;
                default:
                    Console.WriteLine("Wrong!");
                    break;

            }
                                    

            return base.VisitIter_stmt(context);
        }

        public override bool VisitExpr([NotNull] GrammarParser.ExprContext context)
        {
            Console.WriteLine("Expression");
            return base.VisitExpr(context);
        }

        public override bool VisitVar_stmt([NotNull] GrammarParser.Var_stmtContext context)
        {
            Console.WriteLine("Var Statement " + context.GetText());    
            

            //Write each child to pythonScript.txt. Each child can be translated if necessary.
            //Should be added to the symbol table or something?
            for (int i = 0; i < context.children.Count; i++)
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.Write(context.GetChild(i).GetText());
                }
            }

            return base.VisitVar_stmt(context);
        }

        public override bool VisitStmt([NotNull] GrammarParser.StmtContext context)
        {
            Console.WriteLine("Statement");

            return base.VisitStmt(context);
        }

        public override bool VisitFunction_expr([NotNull] GrammarParser.Function_exprContext context)
        {
            Console.WriteLine("Function Expression");

            switch (context.GetChild(0).GetText())
            {
                case "Drive":                    
                    int distance = Convert.ToInt32(context.GetChild(2).GetText());
                    int speed = Convert.ToInt32(context.GetChild(4).GetText()) * 10;
                    int pauseTime = Math.Abs(distance / (speed / 10));

                    using (StreamWriter sw = File.AppendText(path))
                    {

                        sw.Write($"self.create.drive_direct({speed}, {speed}){prefix}" +
                            $"self.time.sleep({pauseTime}){prefix}" +
                            $"self.create.drive_direct(0,0){prefix}");
                    }

                    
                    break;
               
                default:
                    Console.WriteLine("Wrong!");
                    break;
                    
            }

            return base.VisitFunction_expr(context);
        }


        public override bool VisitVar_decl([NotNull] GrammarParser.Var_declContext context)
        {
            Console.WriteLine("Variable Declaration " + context.GetText());

            return base.VisitVar_decl(context);
        }

        public override bool VisitVar_expr([NotNull] GrammarParser.Var_exprContext context)
        {
            Console.WriteLine(context.GetText());
            return base.VisitVar_expr(context);
        }
        public override bool VisitPrint([NotNull] GrammarParser.PrintContext context)
        {
            Console.WriteLine("Print");
            return base.VisitPrint(context);
        }

        public override bool VisitNum_expr([NotNull] GrammarParser.Num_exprContext context)
        {
            Console.WriteLine($"Numeric Expression {context.GetText()}");

            return base.VisitNum_expr(context);
        }
        
    }
}
