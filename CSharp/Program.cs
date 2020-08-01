using System;
using System.Diagnostics;
using System.IO;

namespace CSharp
{
    public static class Program
    {
        public const int Iterations = 1000;
        private const int TestRuns = 10;

        public static readonly string BaseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        public static readonly string LogFilename = "TestsOutputC#.log";

        private delegate void TestDelegate();

        private static void Main()
        {
            File.Delete(Path.Combine(BaseDirectory, LogFilename));

            var debug = false;
            #if DEBUG
                debug = true;
            #endif

            var stopwatch = Stopwatch.StartNew();

            /*
             *  FileTests
             */
            LogText($"FileTests{Environment.NewLine}");
            FileTests.DeleteTestFiles();

            RunTestsFor(FileTests.ReadFile_AllText);
            RunTestsFor(FileTests.ReadFile_ByLine);
            RunTestsFor(FileTests.WriteFile_AllText);
            RunTestsFor(FileTests.WriteFile_ByLine);
            RunTestsFor(FileTests.RenameFiles);
            RunTestsFor(FileTests.CopyFiles);
            RunTestsFor(FileTests.DeleteFiles);

            LogText();

            /*
             *  StringTests
             */

            //LogText($"StringTests{Environment.NewLine}");

            //

            //LogText();

            /*
             *  NumberTests
             */

            //LogText($"NumberTests{Environment.NewLine}");

            //

            //LogText();

            stopwatch.Stop();
            LogText();
            LogText($"All tests executed in {stopwatch.Elapsed.TotalMinutes} minutes");
            LogText($"DEBUG = {debug}");
            Console.WriteLine($"Log file saved in {BaseDirectory}{LogFilename}");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        public static void PrintElapsedTime(Stopwatch stopwatch, int? iterations = null)
        {
            var testIterations = iterations ?? Iterations;

            var stackTrace = new StackTrace();
            var callingMethod = stackTrace.GetFrame(1)?.GetMethod()?.Name;

            LogText($"{callingMethod} N = {testIterations} = {stopwatch.Elapsed.TotalSeconds} seconds");
        }

        private static void RunTestsFor(TestDelegate testDelegate)
        {
            for (var i = 0; i < TestRuns; i++)
            {
                testDelegate();
            }

            LogText();
        }

        public static void LogText(string text = null)
        {
            Console.WriteLine(text);

            using (var logFile = File.AppendText(Path.Combine(BaseDirectory, LogFilename)))
            {
                logFile.WriteLine(text);
            }
        }
    }
}
