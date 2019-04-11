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
                if (int.TryParse(context.GetChild(0).GetText(), out var result))
                {
                    return EExpressionType.Int;
                }
                else if (float.TryParse(context.GetChild(0).GetText(), out var result2))
                {
                    return EExpressionType.Float;
                }
                else
                {
                    return EExpressionType.Unknown;
                }
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
    }
}
