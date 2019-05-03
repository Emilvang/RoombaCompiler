using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime.Misc;

namespace RoombaCompiler2
{
    public class TypeListenerEx : GrammarBaseListener
    {

        public override void EnterVar_decl([NotNull] GrammarParser.Var_declContext context)
        {

            foreach(var child in context.children)
            {
                Console.WriteLine(child.GetText());
            }

            string variableType = context.GetChild(0).GetText();

            string expression = context.GetChild(3).GetText();

            if (variableType == "int")
            {
                NumHandler(SplitExpression(expression), "int");
            }
            else if (variableType == "float")
            {
                NumHandler(SplitExpression(expression), "float");
            }
            else
            {
                BoolHandler(expression);
            }


            base.EnterVar_decl(context);
        }

        public override void EnterNum_expr([NotNull] GrammarParser.Num_exprContext context)
        {
            string[] expressions = SplitExpression(context.GetText());
            
            //Works for ints, but how to differentiate between checking floats and ints?
            NumHandler(expressions, null);

            base.EnterNum_expr(context);
        }
        //For ints..Not sure how to check for floats, since a numeric expression can be both. 
        private void NumHandler(string[] expressions, string type)
        {
            foreach (var expression in expressions)
            {
                if (type == "float" || type == null)
                {
                    if (!float.TryParse(expression, out var result))
                    {
                        try
                        {
                            var variableExpression = MainScopeClass.ReturnValueFromScope(expression);
                            NumHandler(SplitExpression(variableExpression), type);
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("Not a float expression!");
                        }

                    }
                }
                else if (type == "int")
                {
                    if (!int.TryParse(expression, out var result))
                    {
                        try
                        {
                            var variableExpression = MainScopeClass.ReturnValueFromScope(expression);
                            NumHandler(SplitExpression(variableExpression), type);
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("Not an integer expression!");
                        }

                    }
                }

                             
            }
        }

        private void BoolHandler(string expression)
        {
            //No clue yo
        }




        private string[] SplitExpression(string expression)
        {
            string[] delimiters = { "*", "+", "/", "-" };
            return expression.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
        }





    }
}
