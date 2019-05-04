using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime.Misc;
using System.Data;

namespace RoombaCompiler2
{
    public class TypeListenerEx : GrammarBaseListener
    {

        public override void EnterVar_decl([NotNull] GrammarParser.Var_declContext context)
        {            

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
        //Works, but pretty ugly..An emergency solution, I guess.
        private void BoolHandler(string expression)
        {

            Tuple<string, bool> TuplePair = SearchAndReplace(expression);

            

            while(TuplePair.Item2)
            {
                TuplePair = SearchAndReplace(TuplePair.Item1);                
                
            }

            DataTable dt = new DataTable();

            try
            {
                Console.WriteLine("Boolean result: " + dt.Compute(TuplePair.Item1, "")); 
            }
            catch(Exception ex)
            {
                Console.WriteLine("Cant compute {0} as boolean!", TuplePair.Item1);
            }
            
           
            
        }

        private string[] SplitExpression(string expression)
        {
            string[] delimiters = { "*", "+", "/", "-"};
            return expression.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
        }
        private Tuple<string, bool> SearchAndReplace(string sourceString)
        {
            bool ReplacedValue = false;

            Dictionary<string, string> TranslateScope = new Dictionary<string, string>();

            TranslateScope.Add("And", " AND ");
            TranslateScope.Add("and", " AND ");
            TranslateScope.Add("Or", " OR ");
            TranslateScope.Add("or", " OR ");
            TranslateScope.Add("==", "=");
            TranslateScope.Add("!=", "<>");

            //Has to replace certain elements for the compute function to work. 
            foreach (var variable in TranslateScope)
            {
                try
                {
                    if (sourceString.Contains(variable.Key.ToString()))
                    {
                        sourceString = sourceString.Replace(variable.Key.ToString(), variable.Value.ToString());
                        ReplacedValue = true;
                        //Console.WriteLine($"Replaced {variable.Key.ToString()} with {variable.Key.ToString()}");
                    }

                }
                catch (Exception)
                {

                }
            }

            //Replacing variables.
            foreach (var Scope in MainScopeClass.Scopes)
            {
                foreach (var variable in Scope.SymbolTable)
                {
                    try
                    {
                        if (sourceString.Contains(variable.Key.ToString()))
                        {
                            //Not quite sure about this one..Seems to work though.
                            sourceString = sourceString.Replace(variable.Key.ToString(), SearchAndReplace(variable.Value.ToString()).Item1);
                            ReplacedValue = true;
                            //Console.WriteLine($"Replaced {variable.Key.ToString()} with {variable.Key.ToString()}");
                        }
                        

                    }
                    catch (Exception)
                    {

                    }
                }
            }
            return new Tuple<string, bool>(sourceString, ReplacedValue);
        }



    }
}
