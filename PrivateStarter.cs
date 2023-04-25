using System;
using System.Collections.Generic;
using System.Text;

namespace MagmaMc.AUU
{
    class PrivateStarter: Global
    {
        private static void Main(string[] args)
        {
            Console.WriteLine(CallAPI(APIEndPoints.UserData, (APIData)new UserData("testaccount", "testaccount")));
        }
    }
}
