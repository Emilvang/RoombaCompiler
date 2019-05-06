using System.Collections.Generic;

namespace RoombaCompiler2.SemanticAnalysis.Models
{
    public class MethodRecord
    {
        public string MethodName { get; }
        public EValueType ReturnType { get; }
        public IReadOnlyDictionary<string, EValueType> Parameters { get; }

        public MethodRecord(string methodName, EValueType returnType, IReadOnlyDictionary<string, EValueType> parameters)
        {
            MethodName = methodName;
            ReturnType = returnType;
            Parameters = parameters;
        }
    }
}
