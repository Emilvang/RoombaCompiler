namespace RoombaCompiler2.SemanticAnalysis.Models
{
    public class Record
    {
        protected string _id;
        protected EVariableType _type;

        public Record(string id, EVariableType type)
        {
            _id = id;
            _type = type;
        }

        public string Id => _id;

        public EVariableType Type => _type;

        public override string ToString() => "Record: " + _id + " : " + _type;
    }
}
