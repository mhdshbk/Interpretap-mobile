using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpretap.Common
{
    public static class Constants
    {
        public static Dictionary<String, String> ProfileTypes = new Dictionary<String, String>
        {
            { "Client", "client" },
            { "Interpreter", "interpreter" }
        };

        public static Dictionary<String, String> Genders = new Dictionary<String, String>
        {
            { "Male", "1" },
            { "Female", "2" }
        };

        public enum UserTypes
        {
            Client, Interpreter, Business, Agency
        }
    }
}
