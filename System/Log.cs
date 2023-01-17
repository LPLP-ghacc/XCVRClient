using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCVRClient.System
{
    public static class Log
    {
        public static void HelloMessage()
        {
            Console.Clear();

            string message = "";

            Console.WriteLine(message);
        } 

        public static void Msg(object message) => MelonLogger.Msg(message);
    }
}
