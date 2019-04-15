using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime.Misc;

namespace RoombaCompiler2
{
    public class ScopeCheckingVisitor : GrammarBaseVisitor<IList<KeyValuePair<string, object>>>
    {
        public override IList<KeyValuePair<string, object>> VisitProgram([NotNull] GrammarParser.ProgramContext context)
        {
            

            return base.VisitProgram(context);
        }
        public override IList<KeyValuePair<string, object>> VisitStmts([NotNull] GrammarParser.StmtsContext context)
        {
            Console.WriteLine("Testing testing: " + GrammarParser.ruleNames[context.Parent.RuleIndex]);
            return base.VisitStmts(context);
        }
    }
}
