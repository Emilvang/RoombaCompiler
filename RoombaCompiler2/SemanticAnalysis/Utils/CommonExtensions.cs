using RoombaCompiler2.SemanticAnalysis.Models;
using System;
using System.Linq;

namespace RoombaCompiler2.SemanticAnalysis.Utils
{
    public static class CommonExtensions
    {
        public static bool IsNumber(this string text) => float.TryParse(text, out _);

        public static bool IsFloat(this string text) => text.IsNumber() && text.Contains(".");

        public static bool IsInteger(this string text) => int.TryParse(text, out _);

        public static bool IsBoolLiteral(this string text) => text == "True" || text == "False";

        public static EVariableType GetVariableType(this string text)
        {
            switch (text)
            {
                case "int":
                    return EVariableType.Integer;
                case "bool":
                    return EVariableType.Boolean;
                case "float":
                    return EVariableType.Float;
                case "void":
                    return EVariableType.Void;          
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
