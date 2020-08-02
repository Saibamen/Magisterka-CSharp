using System;
using System.Diagnostics;
using System.Linq;

namespace CSharp
{
    public static class StringTests
    {
        // 500 characters
        private const string TestString = "ThisIsExample123StringToTestStringOperationsTESTweThisIsExample123StringToTestStringOperationsTEST!@ThisIsExample123StringToTestStringOperationsTESTweThisIsExample123StringToTestStringOperationsTEST!@ThisIsExample123StringToTextToSearcherationsTESTweThisIsExample123StringToTestStringOperationsTEST!@ThisIsExample123StringToTestStringOperationsTESTweThisIsExample123StringToTestStringOperationsTEST!@ThisIsExample123StringToTestStringOperationsTESTweThisIsExample123StringToTestStringOperationsTEST!@";

        // NOTE: Increased to 1000000 iterations. Time in milliseconds
        public static void AscTest()
        {
            const int testIterations = 1000000;
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

        // NOTE: Increased to 1000000 iterations. Time in milliseconds
        public static void MidTest()
        {
            const int testIterations = 1000000;
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

        // NOTE: Increased to 1000000 iterations. Time in milliseconds
        public static void LeftTest()
        {
            const int testIterations = 1000000;
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

        // NOTE: Increased to 1000000 iterations. Time in milliseconds
        public static void RightTest()
        {
            const int testIterations = 1000000;
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

        // NOTE: Increased to 1000000 iterations. Time in milliseconds
        public static void TrimTest()
        {
            const int testIterations = 1000000;
            string returnVar;

            var stopwatch = Stopwatch.StartNew();

            for (var i = 0; i < testIterations; i++)
            {
                // 520 characters, 10 whitespaces both at beginning and end
                var textToTrim = "          ThisIsExample123StringToTestStringOperationsTESTweThisIsExample123StringToTestStringOperationsTEST!@ThisIsExample123StringToTestStringOperationsTESTweThisIsExample123StringToTestStringOperationsTEST!@ThisIsExample123StringToTextToSearcherationsTESTweThisIsExample123StringToTestStringOperationsTEST!@ThisIsExample123StringToTestStringOperationsTESTweThisIsExample123StringToTestStringOperationsTEST!@ThisIsExample123StringToTestStringOperationsTESTweThisIsExample123StringToTestStringOperationsTEST!@          ";

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

        // NOTE: Increased to 1000000 iterations. Time in milliseconds
        public static void LenTest()
        {
            const int testIterations = 1000000;
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

        // NOTE: Increased to 1000000 iterations
        public static void LCaseTest()
        {
            const int testIterations = 1000000;
            string returnVar;

            var stopwatch = Stopwatch.StartNew();

            for (var i = 0; i < testIterations; i++)
            {
                returnVar = TestString?.ToLower();
            }

            stopwatch.Stop();
            Program.PrintElapsedTime(stopwatch, testIterations);
        }

        // NOTE: Increased to 1000000 iterations
        public static void UCaseTest()
        {
            const int testIterations = 1000000;
            string returnVar;

            var stopwatch = Stopwatch.StartNew();

            for (var i = 0; i < testIterations; i++)
            {
                returnVar = TestString?.ToUpper();
            }

            stopwatch.Stop();
            Program.PrintElapsedTime(stopwatch, testIterations);
        }

        // NOTE: Increased to 1000000 iterations
        public static void ReplaceTest()
        {
            const int testIterations = 1000000;
            string returnVar;

            var stopwatch = Stopwatch.StartNew();

            for (var i = 0; i < testIterations; i++)
            {
                returnVar = TestString.Replace("TextToSearch", "ChangedText1");
            }

            stopwatch.Stop();
            Program.PrintElapsedTime(stopwatch, testIterations);
        }

        // NOTE: Increased to 1000000 iterations
        public static void PadLeftTest()
        {
            const int testIterations = 1000000;
            string returnVar;

            var stopwatch = Stopwatch.StartNew();

            for (var i = 0; i < testIterations; i++)
            {
                returnVar = TestString.PadLeft(1000, '#');
            }

            stopwatch.Stop();
            Program.PrintElapsedTime(stopwatch, testIterations);
        }
    }
}
