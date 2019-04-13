using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime.Misc;

namespace RoombaCompiler2
{
    class Listerner : GrammarBaseListener
    {

        public Stack<Scope> ScopeStack { get; set; }
        public override void EnterProgram([NotNull] GrammarParser.ProgramContext context)
        {
            
            base.EnterProgram(context);
        }
    }
}
