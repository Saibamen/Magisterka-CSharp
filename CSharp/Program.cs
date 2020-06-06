using System;
using System.Diagnostics;
using System.IO;

namespace CSharp
{
    public class Program
    {
        private const int TestAttempts = 10;
        private const int Iterations = 1000;

        private static readonly string BaseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        private static readonly string ReadTestFile = $"{BaseDirectory}{Path.DirectorySeparatorChar}da51f72f-7804-40fe-bc66-8fc5418325fb_001.data";

        private static void Main()
        {
            for (var i = 0; i < TestAttempts; i++)
            {
                ReadFile_ReadAllText();
            }

            Console.WriteLine();

            for (var i = 0; i < TestAttempts; i++)
            {
                ReadFile_ByLine();
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        private static void ReadFile_ReadAllText()
        {
            var stopwatch = Stopwatch.StartNew();

            for (var i = 0; i < Iterations; i++)
            {
                File.ReadAllText(ReadTestFile);
            }

            stopwatch.Stop();
            PrintElapsedTime(stopwatch);
        }

        private static void ReadFile_ByLine()
        {
            var stopwatch = Stopwatch.StartNew();

            for (var i = 0; i < Iterations; i++)
            {
                var fileStream = new FileStream(ReadTestFile, FileMode.Open);
                using var streamReader = new StreamReader(fileStream);
                streamReader.ReadLine();
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
