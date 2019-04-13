using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoombaCompiler2
{
    public static class MainScopeClass
    {
        public static Dictionary<string, object> MainScope = new Dictionary<string, object>();           


        public static void AddElements()
        {
            MainScope.Add("And", " AND ");
            MainScope.Add("and", " AND ");
            MainScope.Add("Or", " OR ");
            MainScope.Add("or", " OR ");
            MainScope.Add("==", "=");
        }

    }
    

}
