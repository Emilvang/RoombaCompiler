﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoombaCompiler2
{
    public class ScopeNode
    {
        public ScopeNode Parent;

        public Dictionary<string, string> SymbolTable = new Dictionary<string, string>();


    }
}
