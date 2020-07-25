using System;
using System.Diagnostics;

namespace CSharp
{
    public static class Program
    {
        public const int Iterations = 1000;
        private const int TestAttempts = 10;

        private delegate void TestDelegate();

        private static void Main()
        {
            bool debug;
            #if DEBUG
                debug = true;
            #endif

            var stopwatch = Stopwatch.StartNew();

            /*
             *  FileTests
             */
            Console.WriteLine($"FileTests{Environment.NewLine}");
            FileTests.DeleteTestFiles();

            RunTestsFor(FileTests.ReadFile_AllText);
            RunTestsFor(FileTests.ReadFile_ByLine);
            RunTestsFor(FileTests.WriteFile_AllText);
            RunTestsFor(FileTests.WriteFile_ByLine);
            RunTestsFor(FileTests.RenameFiles);
            RunTestsFor(FileTests.CopyFiles);
            RunTestsFor(FileTests.DeleteFiles);

            Console.WriteLine();

            /*
             *  StringTests
             */

            //Console.WriteLine($"StringTests{Environment.NewLine}");

            //

            //Console.WriteLine();

            /*
             *  NumberTests
             */

            //Console.WriteLine($"NumberTests{Environment.NewLine}");

            //

            //Console.WriteLine();

            stopwatch.Stop();
            Console.WriteLine();
            Console.WriteLine($"All tests executed in {stopwatch.Elapsed.TotalMinutes} minutes");
            Console.WriteLine($"DEBUG = {debug}");
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
