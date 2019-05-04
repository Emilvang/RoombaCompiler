using RoombaCompiler2.SemanticAnalysis.Models;
using System.Collections.Generic;

namespace RoombaCompiler2.SemanticAnalysis
{
    public class SymbolTable
    {
        private Scope _root; // the root scope
        private Scope _current; // current scope

        public SymbolTable()
        {
            _root = new Scope(null);
            _current = _root;
        }

        // create a new scope if necessary
        public void EnterScope() => _current = _current.NextChild();

        public void SetScopeType(string scopeType) => _current.ScopeType = scopeType;

        public void ExitScope() => _current = _current.GetParent();

        public void Put(string key, Record item) => _current.Put(key, item);

        public Record Lookup(string key) => _current.Lookup(key);

        // called before each traversal
        public void ResetTable() => _root.ResetScope();

        private class Scope
        {
            private int _next = 0; // next child to visit
            private Scope _parent; // parent scope                              
            private List<Scope> _children = new List<Scope>(); // children scopes
            private Dictionary<string, Record> _records = new Dictionary<string, Record>();
            private string _scopeNestness = string.Empty;

            private string ScopeName => _scopeNestness + " " + ScopeType;
            public string ScopeType { get; set; } = string.Empty;

            public Scope(Scope parent)
            {
                _parent = parent;

                // Used for debugging
                if (parent != null && parent._parent == null)
                    _scopeNestness = (parent._children.Count + 1).ToString();
                else if (parent != null)
                    _scopeNestness = _parent._scopeNestness + "." + (parent._children.Count + 1).ToString();
            }

            // add a new record to the current scope
            public void Put(string key, Record item) => _records.Add(key, item);

            public Scope NextChild()
            {
                Scope nextChild;
                if (_next >= _children.Count)
                {
                    nextChild = new Scope(this); // create a new Scope passing the parent scope
                    _children.Add(nextChild);
                }
                else
                {
                    // child exists
                    nextChild = _children[_next]; // visited the next
                                                  // child (Scope)
                }
                _next++;
                return nextChild;
            }

            public Record Lookup(string key)
            {
                if (_records.ContainsKey(key))
                { // is the key in current scope?
                    Record rec = _records[key];
                    return rec;
                }
                else
                {
                    // move the scope to parent scope
                    if (_parent == null)
                    {
                        return null; // identifier is not contained
                    }
                    else
                    {
                        return _parent.Lookup(key); // send the req to parent
                    }
                }
            }

            public void ResetScope()
            {
                _next = 0; // first child to visit next
                for (int i = 0; i < _children.Count; i++)
                {
                    _children[i].ResetScope();
                }
            }

            public Scope GetParent() => _parent;
        }
    }
}