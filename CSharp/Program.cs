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

            LogText($"{DateTime.Now}{Environment.NewLine}");

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

            LogText($"StringTests{Environment.NewLine}");

            RunTestsFor(StringTests.AscTest);
            RunTestsFor(StringTests.MidTest);
            RunTestsFor(StringTests.LeftTest);
            RunTestsFor(StringTests.RightTest);
            RunTestsFor(StringTests.TrimTest);
            RunTestsFor(StringTests.LenTest);
            RunTestsFor(StringTests.LCaseTest);
            RunTestsFor(StringTests.UCaseTest);
            RunTestsFor(StringTests.ReplaceTest);
            RunTestsFor(StringTests.PadLeftTest);

            LogText();

            /*
             *  NumberTests
             */

            LogText($"NumberTests{Environment.NewLine}");

            RunTestsFor(NumberTests.IntTest);
            RunTestsFor(NumberTests.RoundDecimalPlacesTest);
            RunTestsFor(NumberTests.BasicMathTest);
            RunTestsFor(NumberTests.ModuloTest);
            RunTestsFor(NumberTests.AtanTest);
            RunTestsFor(NumberTests.ExpTest);
            RunTestsFor(NumberTests.RandomNumberTest);

            LogText();

            stopwatch.Stop();
            LogText($"All tests executed in {Math.Round(stopwatch.Elapsed.TotalMinutes, 3)} minutes");
            LogText($"DEBUG = {debug}");
            Console.WriteLine($"Log file saved in {BaseDirectory}{LogFilename}");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        public static void PrintElapsedTime(Stopwatch stopwatch, int? iterations = null, bool printMilliseconds = false)
        {
            var testIterations = iterations ?? Iterations;

            var stackTrace = new StackTrace();
            var callingMethod = stackTrace.GetFrame(1)?.GetMethod()?.Name;

            var timeToShow = stopwatch.Elapsed.TotalSeconds;
            var timeUnit = "seconds";
            var roundDecimal = 3;

            if (printMilliseconds)
            {
                timeToShow = stopwatch.Elapsed.TotalMilliseconds;
                timeUnit = "milliseconds";
                roundDecimal = 1;
            }

            LogText($"{callingMethod} N = {testIterations} = {Math.Round(timeToShow, roundDecimal)} {timeUnit}");
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
