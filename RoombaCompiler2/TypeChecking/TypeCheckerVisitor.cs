using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime.Misc;

namespace RoombaCompiler2.TypeChecking
{
    public class TypeCheckerVisitor : GrammarBaseVisitor<EExpressionType>
    {
        public override EExpressionType VisitNum_expr([NotNull] GrammarParser.Num_exprContext context)
        {
            if (context.ChildCount == 1)
            {
                var element = context.GetChild(0).GetText();                

                int result = 0;
                if (int.TryParse(element, out result))
                {
                    return EExpressionType.Int;
                }
                else
                {
                    element = LookUp(element);

                    if (int.TryParse(element, out result))
                    {
                        return EExpressionType.Int;
                    }

                }
                float result2 = 0;
                if (float.TryParse(element, out result2))
                {
                    return EExpressionType.Float;
                }
                else
                {
                    element = LookUp(element);

                    if (float.TryParse(element, out result2))
                    {
                        return EExpressionType.Float;
                    }
                }
                
                return EExpressionType.Unknown;
                
            }
            else if (context.ChildCount == 3)
            {
                var lhs = context.GetChild(0);
                var lhsType = Visit(lhs);

                var rhs = context.GetChild(2);
                var rhsType = Visit(rhs);

                if (lhsType != rhsType)
                {
                    throw new Exception("Type missmatch");
                }
            }
            else
            {
                throw new NotImplementedException("Grammar has changed!");
            }

            return base.VisitNum_expr(context);
        }
        private string LookUp(string expression)
        {

            foreach (var Scope in MainScopeClass.Scopes)
            {
                //Could add a try instead of checking each variable for more efficiency.
                foreach (var pair in Scope.SymbolTable)
                {
                    if (pair.Key == expression)
                    {
                        return pair.Value;
                    }
                }
            }
            throw new Exception("Can't find variable in scopes!");

        }
        private string SearchAndReplace(string sourceString)
        {
            foreach (var Scope in MainScopeClass.Scopes)
            {
                foreach (var variable in Scope.SymbolTable)
                {
                    try
                    {
                        if (sourceString.Contains(variable.Key.ToString()))
                        {
                            sourceString = sourceString.Replace(variable.Key.ToString(), variable.Value.ToString());
                            Console.WriteLine($"Replaced {variable.Key.ToString()} with {variable.Value.ToString()}");
                        }

                    }
                    catch (Exception)
                    {

                    }
                }
            }
            return sourceString;
        }
    }
}
