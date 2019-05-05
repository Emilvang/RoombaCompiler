namespace RoombaCompiler2.SemanticAnalysis.Models
{
    public class Record
    {
        protected string _id;
        protected EValueType _type;

        public Record(string id, EValueType type)
        {
            _id = id;
            _type = type;
        }

        public string Id => _id;

        public EValueType Type => _type;

        public override string ToString() => "Record: " + _id + " : " + _type;
    }
}
