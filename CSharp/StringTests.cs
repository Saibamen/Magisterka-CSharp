using System;
using System.Diagnostics;
using System.Linq;

namespace CSharp
{
    public static class StringTests
    {
        // TODO: StringModule
        // Łączenie stringów, Pad, czy ma liczbę, szukanie tekstu, usuwanie tekstu

        private const string TestString = "ThisIsExample123StringToTestStringOperationsWoSpacThisIsExample123StringToTestStringOperationsWoSpac";

        // NOTE: Increased to 32000 iterations. Time in milliseconds
        public static void AscTest()
        {
            const int testIterations = 32000;
            int returnVar;

            var stopwatch = Stopwatch.StartNew();

            for (var i = 0; i < testIterations; i++)
            {
                if (string.IsNullOrEmpty(TestString))
                {
                    returnVar = 0;
                }
                else
                {
                    returnVar = TestString.First();
                }
            }

            stopwatch.Stop();
            Program.PrintElapsedTime(stopwatch, testIterations, true);
        }

        // NOTE: Increased to 32000 iterations. Time in milliseconds
        public static void MidTest()
        {
            const int testIterations = 32000;
            string returnVar;

            var stopwatch = Stopwatch.StartNew();

            for (var i = 0; i < testIterations; i++)
            {
                if (string.IsNullOrEmpty(TestString))
                {
                    returnVar = "";
                }
                else
                {
                    const int start = 20;
                    const int length = 50;

                    var part = TestString.Length < start ? "" : TestString.Substring(start - 1);
                    returnVar =  part.Length > length ? part.Substring(0, length) : part;
                }
            }

            stopwatch.Stop();
            Program.PrintElapsedTime(stopwatch, testIterations, true);
        }

        // NOTE: Increased to 32000 iterations. Time in milliseconds
        public static void LeftTest()
        {
            const int testIterations = 32000;
            string returnVar;

            var stopwatch = Stopwatch.StartNew();

            for (var i = 0; i < testIterations; i++)
            {
                if (string.IsNullOrEmpty(TestString))
                {
                    returnVar = "";
                }
                else
                {
                    const int length = 50;

                    var lengthSafe = Math.Min(TestString.Length, length);
                    returnVar = TestString.Substring(0, lengthSafe);
                }
            }

            stopwatch.Stop();
            Program.PrintElapsedTime(stopwatch, testIterations, true);
        }

        // NOTE: Increased to 32000 iterations. Time in milliseconds
        public static void RightTest()
        {
            const int testIterations = 32000;
            string returnVar;

            var stopwatch = Stopwatch.StartNew();

            for (var i = 0; i < testIterations; i++)
            {
                if (string.IsNullOrEmpty(TestString))
                {
                    returnVar = "";
                }
                else
                {
                    const int length = 50;

                    // index should be >= 0
                    var indexSafe = Math.Max(0, TestString.Length - length);
                    // ... and not more than TestString.Length
                    indexSafe = Math.Min(indexSafe, TestString.Length);
                    returnVar = TestString.Substring(indexSafe);
                }
            }

            stopwatch.Stop();
            Program.PrintElapsedTime(stopwatch, testIterations, true);
        }

        // NOTE: Increased to 32000 iterations. Time in milliseconds
        public static void TrimTest()
        {
            const int testIterations = 32000;
            string returnVar;

            var stopwatch = Stopwatch.StartNew();

            for (var i = 0; i < testIterations; i++)
            {
                var textToTrim = "      ThisIsExample123StringToTestStringOperationsThisIsExample123StringToTestStringOperations      ";

                if (string.IsNullOrEmpty(textToTrim))
                {
                    returnVar = "";
                }
                else
                {
                    returnVar = textToTrim.Trim();
                }
            }

            stopwatch.Stop();
            Program.PrintElapsedTime(stopwatch, testIterations, true);
        }

        // NOTE: Increased to 32000 iterations. Time in milliseconds
        public static void LenTest()
        {
            const int testIterations = 32000;
            int returnVar;

            var stopwatch = Stopwatch.StartNew();

            for (var i = 0; i < testIterations; i++)
            {
                if (string.IsNullOrEmpty(TestString))
                {
                    returnVar = 0;
                }
                else
                {
                    returnVar = TestString.Length;
                }
            }

            stopwatch.Stop();
            Program.PrintElapsedTime(stopwatch, testIterations, true);
        }

        // NOTE: Increased to 32000 iterations. Time in milliseconds
        public static void LCaseTest()
        {
            const int testIterations = 32000;
            string returnVar;

            var stopwatch = Stopwatch.StartNew();

            for (var i = 0; i < testIterations; i++)
            {
                returnVar = TestString?.ToLower();
            }

            stopwatch.Stop();
            Program.PrintElapsedTime(stopwatch, testIterations, true);
        }

        // NOTE: Increased to 32000 iterations. Time in milliseconds
        public static void UCaseTest()
        {
            const int testIterations = 32000;
            string returnVar;

            var stopwatch = Stopwatch.StartNew();

            for (var i = 0; i < testIterations; i++)
            {
                returnVar = TestString?.ToUpper();
            }

            stopwatch.Stop();
            Program.PrintElapsedTime(stopwatch, testIterations, true);
        }

        // TODO: val?
    }
}
