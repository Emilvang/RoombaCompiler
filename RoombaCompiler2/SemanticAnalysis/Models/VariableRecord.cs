namespace RoombaCompiler2.SemanticAnalysis.Models
{
    public class VariableRecord
    {
        protected string _id;
        protected EValueType _type;

        public VariableRecord(string id, EValueType type)
        {
            _id = id;
            _type = type;
        }

        public string Id => _id;

        public EValueType Type => _type;

        public override string ToString() => "Record: " + _id + " : " + _type;
    }
}
