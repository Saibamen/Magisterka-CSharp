using System;
using System.Diagnostics;

namespace CSharp
{
    public class Program
    {
        public const int Iterations = 1000;
        private const int TestAttempts = 10;

        private delegate void TestDelegate();

        private static void Main()
        {
            /*
             *  FileModule
             */
            Console.WriteLine($"FileModule{Environment.NewLine}");

            RunTestsFor(FileModule.ReadFile_AllText);
            RunTestsFor(FileModule.ReadFile_ByLine);
            RunTestsFor(FileModule.WriteFile_AllText);
            RunTestsFor(FileModule.WriteFile_ByLine);
            RunTestsFor(FileModule.RenameFiles);
            RunTestsFor(FileModule.CopyFiles);
            RunTestsFor(FileModule.DeleteFiles);

            Console.WriteLine();

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

        private static void RunTestsFor(TestDelegate testDelegate)
        {
            for (var i = 0; i < TestAttempts; i++)
            {
                testDelegate();
            }

            Console.WriteLine();
        }
    }
}
