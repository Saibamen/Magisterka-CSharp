using System;
using System.Diagnostics;

namespace CSharp
{
    public class Program
    {
        public const int Iterations = 1000;
        private const int TestAttempts = 10;

        private static void Main()
        {
            for (var i = 0; i < TestAttempts; i++)
            {
                FileModule.ReadFile_ReadAllText();
            }

            Console.WriteLine();

            for (var i = 0; i < TestAttempts; i++)
            {
                FileModule.ReadFile_ByLine();
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        public static void PrintElapsedTime(Stopwatch stopwatch)
        {
            var stackTrace = new StackTrace();
            var callingMethod = stackTrace.GetFrame(1)?.GetMethod()?.Name;

            Console.WriteLine($"{callingMethod} N = {Iterations} = {stopwatch.Elapsed.TotalSeconds} seconds");
        }
    }
}
