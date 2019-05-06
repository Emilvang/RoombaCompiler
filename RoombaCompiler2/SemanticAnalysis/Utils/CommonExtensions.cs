﻿using RoombaCompiler2.SemanticAnalysis.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RoombaCompiler2.SemanticAnalysis.Utils
{
    public static class CommonExtensions
    {
        public static bool IsNumber(this string text) => float.TryParse(text, out _);

        public static bool IsFloat(this string text) => text.IsNumber() && text.Contains(".");

        public static bool IsInteger(this string text) => int.TryParse(text, out _);

        public static bool IsBoolLiteral(this string text) => text == "True" || text == "False";

        public static bool IsInteger(this EValueType valueType) => valueType == EValueType.Float || valueType == EValueType.Integer;

        public static IReadOnlyDictionary<K, V> ToReadOnlyDictionary<K, V>(this IDictionary<K, V> dictionary) =>
            dictionary.ToDictionary(x => x.Key, x => x.Value);

        public static EValueType GetVariableType(this string text)
        {
            switch (text)
            {
                case "int":
                    return EValueType.Integer;
                case "bool":
                    return EValueType.Boolean;
                case "float":
                    return EValueType.Float;
                case "void":
                    return EValueType.Void;          
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
