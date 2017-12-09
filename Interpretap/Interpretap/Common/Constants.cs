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
            { "User", "user" },
            { "Interpreter", "interpreter" }
        };
    }
}
