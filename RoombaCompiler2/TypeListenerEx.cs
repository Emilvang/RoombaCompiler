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

        public override void EnterArithmetic_expr([NotNull] GrammarParser.Arithmetic_exprContext context)
        {

            string[] expressions = SplitExpression(context.GetText());

            foreach (var expression in expressions)
            {
                if(int.TryParse(expression, out var result))
                {

                }


                Console.WriteLine(expression);
            }





            
            base.EnterArithmetic_expr(context);
        }


        private string[] SplitExpression(string expression)
        {
            string[] delimiters = { "*", "+", "/", "-" };
            return expression.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
        }





    }
}
