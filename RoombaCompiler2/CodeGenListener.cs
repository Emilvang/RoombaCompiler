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


    /*Issues:
     * Turn command doesn't exist, have to find a way to do it with drive_direct    
     * Built in functions are fucked, and I can't find where they are declared.
     * */


namespace RoombaCompiler2
{
    class CodeGenListener : GrammarBaseListener
    {
        public string GeneratedCode { get; set; }
        public string prefix = "\r\n\t\t";

        public CodeGenListener()
        {
            GeneratedCode = "";
        }
        
        public override void EnterProgram([NotNull] GrammarParser.ProgramContext context)
        {
            GeneratedCode += "class Run:\r\n\t" +               
                "def __init__(self,factory):\r\n\t\t\"\"\"" +
                "Constructor.\r\n\t\t" +
                    "Args:\r\n\t\t\t" +
                    "factory (factory.FactoryCreate)\r\n\t\t\"\"\"\r\n\t\t" +
                    "self.create = factory.create_create()\r\n\t\t" +
                    "self.servo = factory.create_servo()\r\n\t\t" +
                    "self.time = factory.create_time_helper()\r\n\t\t" +
                    "self.virtual_create = factory.create_virtual_create()\r\n\t" +                    
                    "def run(self):\r\n\t\t" +
                    "self.create.start()\r\n\t\t" +
                    "self.create.full()\r\n\t";
            base.EnterProgram(context);
        }
                

        public override void ExitProgram([NotNull] GrammarParser.ProgramContext context)
        {
            //Necessary? Not sure
            GeneratedCode += prefix + "self.create.stop()";
            base.ExitProgram(context);
        }

        public override void EnterFunc_stmt([NotNull] GrammarParser.Func_stmtContext context)
        {

            CreateDefaultFunction(context);

            base.EnterFunc_stmt(context);
        }

        //Probably needs an update with added parameter to the grammar.
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
            prefix = RemovePrefix();

            base.ExitFunc_stmt(context);
        }
        public override void EnterFunc_expr([NotNull] GrammarParser.Func_exprContext context)
        {

            switch (context.GetChild(0).GetText())
            {

                case "Drive":
                    //4 = One argument for Drive.
                    if (context.ChildCount == 4)
                    {
                        GeneratedCode += DriveOneArgument(context.GetChild(4).GetText());
                    }
                    //else: two arguments for Drive
                    else
                    {
                        GeneratedCode += DriveTwoArguments(context.GetChild(2).GetText(), context.GetChild(4).GetText());
                    }
                    break;
                case "Turn":
                    GeneratedCode += Turn(context.GetChild(2).GetText());
                    break;
                case "CoverCircle":
                    CoverCircle(context);
                    break;
                case "CoverRectangle":
                    CoverRectangle(context);
                    break;
                case "Stop":
                    Stop();
                    break;
                case "Dock":
                    Dock();
                    break;
                default:
                    DefaultFuncExprHandler(context);
                    //GeneratedCode += prefix + context.GetText();
                    break;
            }
            base.EnterFunc_expr(context);
        }


        private void DefaultFuncExprHandler(GrammarParser.Func_exprContext context)
        {           
                      

            var parentType = context.Parent.GetType();

            if (parentType == typeof(GrammarParser.StmtContext))
            {
                GeneratedCode += prefix + context.GetText();

            }

        }

        //Needs an update based on DriveTwoArguments, or be removed.
        private string DriveOneArgument(string speed)
        {
            string stringToReturn = "";
            int seconds = 10;
            //Multiplied by 10 because we set it as cm/s, not mm/s. 
            stringToReturn += $"{prefix}self.create.drive_direct(({speed})*10, {speed}*10)";
            stringToReturn += $"{prefix}self.time.sleep({seconds})";

            return stringToReturn;

        }
        private string DriveTwoArguments(string distance, string speed)
        {
            
            string stringToReturn = "";                    
                       
            //Get the time: I think it works.
            string seconds = $"{distance} / ({speed}) ";


            //Multiplied by 10 because we set it as cm/s, not mm/s.
            
            stringToReturn += $"{prefix}self.create.drive_direct({speed}*10, {speed}*10)";
            stringToReturn += $"{prefix}self.time.sleep({seconds})";

            return stringToReturn;
        }
                
        private string Turn(string degrees)
        {

            string stringToReturn = "";

            string addition = $"({degrees}/180)*0.05";

            stringToReturn += $"{prefix}self.create.drive_direct(-{degrees},{degrees})";
            stringToReturn += $"{prefix}self.time.sleep(2+{addition})";

            return stringToReturn;
           

        }
        private void CoverCircle(GrammarParser.Func_exprContext context)
        {

            string numberOfCircles = context.GetChild(2).GetText();

            string stringToReturn = "";
            stringToReturn += $"{prefix}for i in range({numberOfCircles}):";
            prefix += "\t";
            stringToReturn += $"{prefix}for j in range(10):";
            prefix += "\t";
            stringToReturn += $"{prefix}self.create.drive_direct(100, 200)";
            stringToReturn += $"{prefix}self.time.sleep(1)";
            stringToReturn += $"{prefix}self.create.drive_direct(50, 50)";
            stringToReturn += $"{prefix}self.time.sleep(i)";
            prefix = RemovePrefix();
            prefix = RemovePrefix();
            GeneratedCode += stringToReturn;

        }
        //Seems to work
        private void CoverRectangle(GrammarParser.Func_exprContext context)
        {
            /*
            Base idea:
            */
            //Clean one line up to h. 
            //Turn 90 degrees.
            //Drive 5 cm to the right?
            //Turn 90 degrees
            //Clean one line down to h.
            //Turn -90 degrees
            //Drive 5 cm to the right
            //Turn -90 degrees
            //Repeat
           
            string width = context.GetChild(2).GetText();

            string height = context.GetChild(4).GetText();
            //The small correction drives after the turns might need to be adjusted. It drives crooked for some reason..Not sure how to fix.

            string stringToAdd = "";
            stringToAdd += $"{prefix}coveredDistance = 0";
            stringToAdd += $"{prefix}while coveredDistance < {width}/100*2:";
            prefix += "\t";
            stringToAdd += DriveTwoArguments(height, "20");
            stringToAdd += Turn("90");
            stringToAdd += DriveTwoArguments("5", "30");
            stringToAdd += Turn("90");
            stringToAdd += DriveTwoArguments(height, "20");
            stringToAdd += Turn("-90");
            stringToAdd += DriveTwoArguments("5", "30");
            stringToAdd += Turn("-90");
            stringToAdd += $"{prefix}coveredDistance = coveredDistance + 1";

            GeneratedCode += stringToAdd;
            prefix = RemovePrefix();

        }
        //No clue
        private void Dock()
        {
            //Couldn't find the necessary code from pycreate2. Just a guess
            GeneratedCode += $"{prefix}self.create.dock()";
        }
        //Is this even necessary?
        private void Stop()
        {
            GeneratedCode += $"{prefix}self.create.drive_direct(0,0)";
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
                    GeneratedCode += $"{prefix}while {SearchAndReplace(expression)}:";
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
            prefix = RemovePrefix();
            base.ExitIter_stmt(context);
        }

        public override void EnterVar_decl([NotNull] GrammarParser.Var_declContext context)
        {
            
            string variableName = context.GetChild(1).GetText();
            string expression = context.GetChild(3).GetText();                       
            
            
            string stringToAdd = $"{variableName} = {SearchAndReplace(expression)}";
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

        public override void EnterReturn_stmt([NotNull] GrammarParser.Return_stmtContext context)
        {
            //Made like this to get spaces in between different expressions and the return keyword.
            string returnCode = "";
            for (int i = 1; i < context.ChildCount; i++)
            {
                returnCode += " " + context.GetChild(i).GetText();
            }
            GeneratedCode += prefix + "return" + returnCode;
            base.EnterReturn_stmt(context);
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

            string stringToAdd = $"if {SearchAndReplace(context.GetChild(1).GetText())}:";
            GeneratedCode += prefix + stringToAdd;
            prefix += "\t";

            base.EnterIf_stmt(context);
        }
        public override void ExitIf_stmt([NotNull] GrammarParser.If_stmtContext context)
        {
            prefix = RemovePrefix();
            base.ExitIf_stmt(context);
        }
        public override void EnterElseif_stmt([NotNull] GrammarParser.Elseif_stmtContext context)
        {
            string stringToAdd = $"elif {SearchAndReplace(context.GetChild(1).GetText())}:";
            GeneratedCode += prefix + stringToAdd;
            prefix += "\t";
            base.EnterElseif_stmt(context);
        }
        public override void ExitElseif_stmt([NotNull] GrammarParser.Elseif_stmtContext context)
        {
            prefix = RemovePrefix();
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
            prefix = RemovePrefix();
            base.ExitElse_stmt(context);
        }

        private string RemovePrefix()
        {
            int index = prefix.IndexOf("\t");
            string cleanPath = (index < 0)
                ? prefix
                : prefix.Remove(index, "\t".Length);

            return cleanPath;

        }
        private string SearchAndReplace(string sourceString)
        {
            //Needs a fix for actual words including the phrases "And" "and" and so on..
            //Needs better solution
            //Quick fix: Only allow AND and OR, but still would prefer more durable solution
            Dictionary<string, string> TranslateScope = new Dictionary<string, string>();

            TranslateScope.Add("+", " + ");
            TranslateScope.Add("-", " - ");
            TranslateScope.Add("/", " / ");
            TranslateScope.Add("*", " * ");
            TranslateScope.Add("AND", " and ");
            TranslateScope.Add("OR", " or ");

            //Has to replace certain elements for the compute function to work. 
            foreach (var variable in TranslateScope)
            {
                try
                {
                    if (sourceString.Contains(variable.Key.ToString()))
                    {
                        sourceString = sourceString.Replace(variable.Key.ToString(), variable.Value.ToString());

                    }

                }
                catch (Exception)
                {

                }
            }

            return sourceString;


        }
    }
}