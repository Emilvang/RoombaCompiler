using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime.Misc;
using System.IO;
using System.Data;


namespace RoombaCompiler2
{
    public class PrintVisitor : GrammarBaseVisitor<bool>
    {
        List<Node> NodeScopes = new List<Node>();
        int testingScopeCount = 0;
        int CurrentScope = 0;
        string prefix = "\r\n\t";
        int scopeCount = 0;
        int realScopeCount = 0;
        //IndexChecker needs more work...
        int IndexChecker = 1;
        string path = @"pythonScript.txt";


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

        public override bool VisitLogic_expr([NotNull] GrammarParser.Logic_exprContext context)
        {

              
            Console.WriteLine("Logical: Children: " + context.ChildCount);
            DataTable dt = new DataTable();
            int children = context.ChildCount;

            var element = SearchAndReplace(context.GetText());

            try
            {
                Console.WriteLine("HERE2:" + dt.Compute(element, "")); 
                
            }
            catch(Exception)
            {
                Console.WriteLine("Error in logical expression");
            }
                   
                            




            return base.VisitLogic_expr(context);
        }

        public override bool VisitCond_stmt([NotNull] GrammarParser.Cond_stmtContext context)
        {
            Console.WriteLine("Conditional statement");
            return base.VisitCond_stmt(context);
        }
        public override bool VisitStmts([NotNull] GrammarParser.StmtsContext context)
        {
            //Not sure how to use these nodes..
            Node node = new Node();
            NodeScopes.Add(node);

            foreach (var child in context.children)
            {
                Node nodeChild = new Node();
                node.children.Add(nodeChild);
            }


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
            /*
            realScopeCount = MainScopeClass.Scopes.Count + 1;
            Dictionary<string, object> localScope = new Dictionary<string, object>();
            Console.WriteLine("REAL scope count: " + realScopeCount);
            MainScopeClass.Scopes.Add(realScopeCount, localScope);

            //Almost..IndexChecker needs a bit of work. 

            if (scopeCount > 0)
            {
                scopeCount--;
            }
            if (!GrammarParser.ruleNames[context.Parent.Parent.Parent.RuleIndex].Equals("program"))
            {                
                foreach (var child in MainScopeClass.Scopes[realScopeCount - IndexChecker])
                {
                    MainScopeClass.Scopes[realScopeCount].Add(child.Key, child.Value);
                }
                IndexChecker++;
                //scopeCount += context.ChildCount;
            
            }
            */



           

            switch (context.GetChild(0).GetText())
            {
                case "for":
                    scopeCount += context.GetChild(7).ChildCount;
                    prefix += "\t";
                    Console.WriteLine("Scopecount = " + scopeCount);
                    //Get the inital and end value of i
                    int Start = Convert.ToInt32(context.GetChild(3).GetText());
                    int End = Convert.ToInt32(context.GetChild(5).GetText());                    
                    using (StreamWriter sw = File.AppendText(path))
                    {
                        sw.Write($"for i in range({Start},{End}):");
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
            Console.WriteLine("Var Statement here " + context.GetText());    
            

            //Write each child to pythonScript.txt. Each child can be translated if necessary.
            //Should be added to the symbol table or something?


            /* Just some experimenting with code generation
            for (int i = 0; i < context.children.Count; i++)
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.Write(context.GetChild(i).GetText());
                }
            }
            */

            return base.VisitVar_stmt(context);
        }

        public override bool VisitStmt([NotNull] GrammarParser.StmtContext context)
        {
            Console.WriteLine("Statement");

            return base.VisitStmt(context);
        }

        public override bool VisitFunc_expr([NotNull] GrammarParser.Func_exprContext context)
        {
            Console.WriteLine("Function Expression");

            switch (context.GetChild(0).GetText())
            {
                case "Drive":

                    int distance;
                    if (Int32.TryParse((context.GetChild(2).GetText()), out distance)) ;
                    else
                    {
                        string variable = Convert.ToString(MainScopeClass.MainScope[context.GetChild(2).GetText()]);
                        Int32.TryParse(variable, out distance);
                    }

                    int speed;
                    if (Int32.TryParse((context.GetChild(4).GetText()), out speed)) ;
                    else
                    {
                        string variable = Convert.ToString(MainScopeClass.MainScope[context.GetChild(4).GetText()]);
                        Int32.TryParse(variable, out speed);
                    }
                    speed *= 10;                    



                    int pauseTime = Math.Abs(distance / (speed / 10));

                    

                    using (StreamWriter sw = File.AppendText(path))
                    {

                        sw.Write($"{prefix}self.create.drive_direct({speed}, {speed})" +
                            $"{prefix}self.time.sleep({pauseTime})" +
                            $"{prefix}self.create.drive_direct(0,0)");
                            scopeCount--;
                            if (scopeCount == 0)
                            {
                                prefix = removePrefix(prefix, "\t");

                            }
                        sw.Write($"{prefix}");
                    }                    
                   
                   

                    break;
               
                default:
                    Console.WriteLine("Wrong!");
                    break;
                    
            }

            return base.VisitFunc_expr(context);
        }


        public override bool VisitVar_decl([NotNull] GrammarParser.Var_declContext context)
        {
            Console.WriteLine("Variable Declaration ");
            DataTable dt = new DataTable();

            


            string expression = context.GetChild(3).GetText();            
                        
            expression = SearchAndReplace(expression);                      

            
            if ((!MainScopeClass.MainScope.ContainsKey(context.GetChild(1).GetText()) || (!(MainScopeClass.Scopes[realScopeCount].ContainsKey(context.GetChild(1).GetText())))))
            {
                if ((!MainScopeClass.MainScope.ContainsKey(context.GetChild(1).GetText())) && realScopeCount == MainScopeClass.Scopes.Count - 1)
                 {
                    MainScopeClass.MainScope.Add(context.GetChild(1).GetText(), dt.Compute(expression, ""));
                    Console.WriteLine($"HERE: {context.GetChild(1).GetText()} {dt.Compute(expression, "")}");
                 }
                else 
                        {
                    MainScopeClass.Scopes[realScopeCount].Add(context.GetChild(1).GetText(), dt.Compute(expression, ""));

                        }               
                
            }
            else
            {
                throw new Exception("Variable already exists!");
            }
            //Add IndexChecker-- here somehow?
            if (scopeCount != 0) scopeCount--;
            if (scopeCount == 0)
            {
                //realScopeCount = IndexChecker;                
                
                if (realScopeCount > 0) { realScopeCount = 0; }
            }


            return base.VisitVar_decl(context);
        }

        public override bool VisitVar_expr([NotNull] GrammarParser.Var_exprContext context)
        {
            Console.WriteLine("Variable Expression" + context.GetText());

            try
            {
                Console.WriteLine(MainScopeClass.MainScope[context.GetText()]);
            }
            catch(Exception)
            {
                Console.WriteLine("Something went wrong..");
            }


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
            if (context.ChildCount == 1)            {
                string expression = SearchAndReplace(context.GetChild(0).GetText());
                try
                {
                    var test = float.Parse(expression);
                    Console.WriteLine("Succesfully accepted!");

                }
                catch(Exception)
                {
                    
                    Console.WriteLine("Error man");
                }
                
            }
            else
            {
                
            }


            return base.VisitNum_expr(context);
        }

        private string removePrefix(string sourceString, string removeString)
        {
            int index = sourceString.IndexOf(removeString);
            string cleanPath = (index < 0)
                ? sourceString
                : sourceString.Remove(index, removeString.Length);

            return cleanPath;

        }
        //Function for finding variables in mathematical expressions and converting them to their int values. Only works on ints and floats. 
        private string SearchAndReplace(string sourceString)
        {            
            foreach (var variable in MainScopeClass.MainScope)
            {                
                try
                {
                    if (sourceString.Contains(variable.Key.ToString()))
                    {
                        sourceString = sourceString.Replace(variable.Key.ToString(), variable.Value.ToString());
                        Console.WriteLine($"Replaced {variable.Key.ToString()} with {variable.Value.ToString()}");
                    }
                    
                }
                catch(Exception)
                {

                }
            }
            return sourceString;
        }

        private void EnterRule()
        {
            Dictionary<string, object> LocalScope = new Dictionary<string, object>();
            MainScopeClass.Scopes.Add(MainScopeClass.Scopes.Count + 1, LocalScope);
            testingScopeCount = MainScopeClass.Scopes.Count;
            CurrentScope = MainScopeClass.Scopes.Count;

        }
        private void ExitRule()
        {
            CurrentScope -= 1;
            testingScopeCount -= 1;
        }

    }
}
