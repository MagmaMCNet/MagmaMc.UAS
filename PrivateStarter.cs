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
            Console.WriteLine(UserData.GetToken((APIData)UserData.GetUserData(new APIData() { { "Username", "testaccount" }, { "Password", "testaccount" } })));
            Console.WriteLine($"Time taken: {stopwatch.ElapsedMilliseconds} ms");

            stopwatch.Restart();
            Console.WriteLine(UserData.GetToken((APIData)CallAPI(APIEndPoints.UserData, (APIData)new UserData("testaccount", "testaccount")).Jsonify()));
            Console.WriteLine($"Time taken: {stopwatch.ElapsedMilliseconds} ms");

            stopwatch.Restart();
            Console.WriteLine(UserData.GetToken(new APIData() { { "Username", "testaccount" }, { "Password", "testaccount" } }));
            stopwatch.Stop();
            Console.WriteLine($"Time taken: {stopwatch.ElapsedMilliseconds} ms");

            stopwatch.Restart();
            Console.WriteLine(UserData.GetToken((APIData)new UserData("testaccount", "testaccount")));
            Console.WriteLine($"Time taken: {stopwatch.ElapsedMilliseconds} ms");
            stopwatch.Stop();
        }
    }
}
