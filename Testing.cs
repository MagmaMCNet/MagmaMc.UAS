using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using MagmaMc.UAA;

namespace MagmaMc.UAA.Test
{
    class Testing: UDUtils
    {
        private static void Main(string[] args)
        {
            var stopwatch = new Stopwatch();

            string UserToken = UserData.GetToken((new APIData() { { "Username", "testaccount" }, { "Password", "testaccount" } }));
            string DevToken = "13d99018931c65a47902c1680f8e7981a8575991.8aedfbd3d5ed506a34602d29fbdfdfb8";
            stopwatch.Restart();
            UserData.SetCustomData(DevToken, UserToken, "Time", $"Time taken: {stopwatch.ElapsedMilliseconds} ms");
            UserData.SetCustomData(DevToken, UserToken, "Time", $"Time taken: {stopwatch.ElapsedMilliseconds} ms");
            Console.WriteLine(UserData.GetCustomData(DevToken, UserToken, "Time"));

            stopwatch.Stop();
        }
    }
}
