using System;
using System.Collections.Generic;

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

        public static class Strings
        {
            public static string SessionKeyInvalidMessage = "Session key is invalid";
            public static string SessionFailed = "Session failed";
            public static string AppResumed = "app_resumed";
        }
    }
}
