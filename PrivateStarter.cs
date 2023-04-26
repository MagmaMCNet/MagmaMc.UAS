using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace MagmaMc.UAA
{
    class PrivateStarter: UDUtils
    {
        private static void Main(string[] args)
        {
            var stopwatch = new Stopwatch();

            stopwatch.Restart();
            string UserToken = UserData.GetToken((new APIData() { { "Username", "testaccount" }, { "Password", "testaccount" } }));
            string DevToken = "13d99018931c65a47902c1680f8e7981a8575991.8aedfbd3d5ed506a34602d29fbdfdfb8";
            UserData.SetCustomData(DevToken, UserToken, "test.txt", "tes2");
            Console.WriteLine(UserData.GetCustomData(DevToken, UserToken, "test.txt"));
            Console.WriteLine($"Time taken: {stopwatch.ElapsedMilliseconds} ms");

            stopwatch.Stop();
        }
    }
}
