using System;
using System.Diagnostics;
using System.IO;

namespace CSharp
{
    public class Program
    {
        private const int TestAttempts = 10;
        private const int Iterations = 1000;

        private static void Main(string[] args)
        {
            for (var i = 0; i < TestAttempts; i++)
            {
                ReadFile();
            }

            Console.ReadKey();
        }

        private static void ReadFile()
        {
            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var file = $"{baseDirectory}{Path.DirectorySeparatorChar}da51f72f-7804-40fe-bc66-8fc5418325fb_001.data";

            var stopwatch = Stopwatch.StartNew();

            for (var i = 0; i < Iterations; i++)
            {
                File.ReadAllText(file);
            }

            stopwatch.Stop();
            PrintElapsedTime(stopwatch);
        }

        private static void PrintElapsedTime(Stopwatch stopwatch)
        {
            var stackTrace = new StackTrace();
            var callingMethod = stackTrace.GetFrame(1)?.GetMethod()?.Name;

            Console.WriteLine($"{callingMethod} N = {Iterations} = {stopwatch.Elapsed.TotalSeconds} seconds");
        }
    }
}
