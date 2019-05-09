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

        public override void ExitProgram([NotNull] GrammarParser.ProgramContext context)
        {
            //Necessary? Not sure
            GeneratedCode += prefix + "self.close()";
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
            prefix = RemovePrefix(prefix, "\t");

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
                        DriveOneArgument(context);
                    }
                    //else: two arguments for Drive
                    else
                    {
                        DriveTwoArguments(context);
                    }
                    break;
                case "Turn":
                    Turn(context);
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
                    GeneratedCode += prefix + context.GetText();
                    break;
            }
            base.EnterFunc_expr(context);
        }
        //Not sure if time.sleep needs to be added somehow? 
        private void DriveOneArgument(GrammarParser.Func_exprContext context)
        {
            string speed = context.GetChild(2).GetText();
            //Multiplied by 10 because we set it as cm/s, not mm/s. 
            GeneratedCode += $"{prefix}self.drive_straight(({speed})*10)";

        }
        private void DriveTwoArguments(GrammarParser.Func_exprContext context)
        {
            string speed = context.GetChild(2).GetText();
            string distance = context.GetChild(4).GetText();
            //Multiplied by 10 because we set it as cm/s, not mm/s. 
            GeneratedCode += $"{prefix}self.drive_distance({distance}, ({speed})*10)";
        }
        private void Turn(GrammarParser.Func_exprContext context)
        {
            string degrees = context.GetChild(2).GetText();
            //Not sure what 0 means? 
            //Should it be turn while driving? Right now it's stationary, I think.
            GeneratedCode += $"{prefix}self.drive_turn({degrees},0)";

        }
        private void CoverCircle(GrammarParser.Func_exprContext context)
        {

        }
        private void CoverRectangle(GrammarParser.Func_exprContext context)
        {
            /*
            Not sure if it works?
            Need to set up simulator
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
            //Repeat until w has been reached, somehow.

            string coveredWidth = "0";
            string width = context.GetChild(2).GetText();

            string height = context.GetChild(4).GetText();
            //Does it accept floats? We need to test this.
            string turnDistance = "0.05";

            string stringToAdd = prefix;
            stringToAdd += $"coveredWidth = {coveredWidth}";
            stringToAdd += $"{prefix}while coveredWidth <= {width}:";
            prefix += "\t";
            stringToAdd += $"{prefix}self.drive_distance(({height}, 100)";
            stringToAdd += $"{prefix}self.drive_stop()";
            stringToAdd += $"{prefix}self.drive_turn(90,0)";
            //Does it need pause here?
            stringToAdd += $"{prefix}self.drive_distance({turnDistance}, 100)";
            stringToAdd += $"{prefix}self.drive_turn(90,0)";
            stringToAdd += $"{prefix}self.drive_distance(({height}, 100)";
            stringToAdd += $"{prefix}self.drive_stop()";
            stringToAdd += $"{prefix}self.drive_turn(-90,0)";
            stringToAdd += $"{prefix}self.drive_distance({turnDistance}, 100)";
            stringToAdd += $"{prefix}self.drive_turn(-90,0)";
            stringToAdd += $"{prefix}coveredWidth += 5";
            GeneratedCode += stringToAdd;
            prefix = RemovePrefix(prefix, "\t");

        }
        private void Dock()
        {
            //Couldn't find the necessary code from pycreate2. Just a guess
            GeneratedCode += $"{prefix}self.dock()";
        }
        private void Stop()
        {
            GeneratedCode += $"{prefix}self.drive_stop()";
        }



        public override void ExitFunc_expr([NotNull] GrammarParser.Func_exprContext context)
        {
            //Do nothing
            base.ExitFunc_expr(context);
        }        
        

        public override void EnterVar_expr([NotNull] GrammarParser.Var_exprContext context)
        {
            GeneratedCode += $"{context.GetText()}";
            base.EnterVar_expr(context);
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
            prefix = RemovePrefix(prefix, "\t");
            base.ExitIter_stmt(context);
        }

        public override void EnterVar_decl([NotNull] GrammarParser.Var_declContext context)
        {
            //Needs work..
            string variableName = context.GetChild(1).GetText();
            string expression = context.GetChild(3).GetText();                       


            //string stringToAdd = $"{variableName} = {SearchAndReplace(expression)}";
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