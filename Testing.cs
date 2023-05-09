using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using MagmaMc.UAS;

namespace MagmaMc.UAS.Test
{
    class Testing: UDUtils
    {
        const bool FormTesting = true;
        const ushort TestLength = 64;
        const string ExampleUserToken = "fe909f4a6c3005b768ab5bbd50b80194ab613eba.dGVzdGFjY291bnQ.29ac470ea9668ed5fb090e4612926968";
        const string ExampleDevToken = "08f7daf58cd18f17bb5f0587b616534cc2b33b72.8aedfbd3d5ed506a34602d29fbdfdfb8";

        private static void Main(string[] args)
        {
            if (FormTesting)
            {
                Application.EnableVisualStyles();
                Application.Run(new LoginForm());
                return;
            }
            Console.Title = "BenchMarking API Response Time";
            List<ushort> Timings = Calculate_Time();
            ushort AverageTime = 0;
            foreach (ushort i in Timings)
                AverageTime += i;
            AverageTime /= TestLength;
            Timings.Clear();

            Console.WriteLine($"Average Time: {AverageTime} ms");
            string stats = "Instant";
            if (AverageTime > 500)
                stats = "Extremely bad";
            else if (AverageTime > 200)
                stats = "Bad";
            else if(AverageTime > 100)
                stats = "Ok";
            else if (AverageTime > 50)
                stats = "Good";

            Console.WriteLine("Simplified Status: {0}", stats);
            Console.WriteLine("\r\n");


            APIResponse Response = CallAPI(APIEndPoints.APIPath, null);

            Console.WriteLine("API Path Called: {0}", APIEndPoints.APIPath);
            Console.WriteLine("Response Message: {0}", Response.Message);
            Console.WriteLine("Response Code: {0}", Response.ResponseCode);
            Console.WriteLine("Response Successful: {0}", Response.Success);  

            Thread.Sleep(5000);
        }

        public static List<ushort> Calculate_Time()
        {
            Stopwatch CalcTime = Stopwatch.StartNew();
            Stopwatch SendTime = new Stopwatch();
            Random random = new Random();
            List<ushort> Timings = new List<ushort>(TestLength);
            for (int i = 0; i < TestLength; i++)
            {
                bool pause = false;
                bool end = false;
                Thread times = new Thread(() =>
                {
                    while (!end)
                    {
                        while(pause)
                        {
                            Thread.Sleep(1);
                        }
                        int l = Console.CursorLeft;
                        int t = Console.CursorTop;
                        Console.CursorVisible = false;
                        Console.SetCursorPosition(8, 0);
                        Console.WriteLine($"{CalcTime.ElapsedMilliseconds / 1000}s {i}/{TestLength}");

                        Console.SetCursorPosition(12 + ((CalcTime.ElapsedMilliseconds / 1000).ToString().Length + i.ToString().Length + TestLength.ToString().Length), 0);
                        Console.Write(SendTime.ElapsedMilliseconds.ToString() + " ms");
                        Console.CursorVisible = true;
                        Console.CursorLeft = l;
                        Console.CursorTop = t;

                    }
                });
                Console.SetCursorPosition(6, 0);
                Console.Write("0");
                Console.SetCursorPosition(0, 0);
                times.Start();

                int length = random.Next(512, 1024);
                StringBuilder stringBuilder = new StringBuilder();
                for (int CharI = 0; CharI < length; CharI++)
                    stringBuilder.Append((char)random.Next(32, 127));
                string randomString = stringBuilder.ToString();

                pause = true;
                Console.WriteLine(length.ToString()+": ");
                Console.SetCursorPosition(0, 1);
                Console.WriteLine("-- HTTP CustomData --");
                Console.WriteLine(randomString);

                Console.SetCursorPosition(6, 0);
                Console.Write("1");
                pause = false;

                SendTime.Restart();
                APIResponse Response = UserData.SetCustomData(ExampleDevToken, ExampleUserToken, "GameValues.Test.dat", randomString);
                Timings.Add((ushort)SendTime.ElapsedMilliseconds);

                if (!Response.Success)
                {
                    pause = true;
                    Console.SetCursorPosition(16 + ((CalcTime.ElapsedMilliseconds / 1000).ToString().Length + i.ToString().Length + TestLength.ToString().Length), 0);
                    Console.Write("ERROR");
                    Thread.Sleep(50);
                    Console.Clear();

                    end = true;
                    continue;
                }
                pause = true;
                Console.SetCursorPosition(6, 0);
                Console.Write("2");
                SendTime.Stop();
                Thread.Sleep(15);

                Console.Clear();
                end = true;
            }
            return Timings;

        }
    }
}
