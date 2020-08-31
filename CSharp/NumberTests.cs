using System;
using System.Diagnostics;

namespace CSharp
{
    public static class NumberTests
    {
        private const int NumberTestsIterations = 1000000;

        // NOTE: Increased to 1000000 iterations. Time in milliseconds
        public static void IntTest()
        {
            int returnVar;

            var stopwatch = Stopwatch.StartNew();

            for (var i = 0; i < NumberTestsIterations; i++)
            {
                returnVar = (int) Math.Floor(32000.9876545569);
            }

            stopwatch.Stop();
            Program.PrintElapsedTime(stopwatch, NumberTestsIterations, true);
        }

        // NOTE: Increased to 1000000 iterations. Time in milliseconds
        public static void RoundDecimalPlacesTest()
        {
            double returnVar;

            var stopwatch = Stopwatch.StartNew();

            for (var i = 0; i < NumberTestsIterations; i++)
            {
                returnVar = Math.Round(32000.9876545569, 3);
            }

            stopwatch.Stop();
            Program.PrintElapsedTime(stopwatch, NumberTestsIterations, true);
        }

        // NOTE: Increased to 1000000 iterations. Time in milliseconds
        public static void BasicMathTest()
        {
            double returnVar;

            var stopwatch = Stopwatch.StartNew();

            for (var i = 0; i < NumberTestsIterations; i++)
            {
                returnVar = (51564981649.3 - 864518.9 + 9841598198.3 * 11869.4) / 6.7423;
            }

            stopwatch.Stop();
            Program.PrintElapsedTime(stopwatch, NumberTestsIterations, true);
        }

        // NOTE: Increased to 1000000 iterations. Time in milliseconds
        public static void SqrtTest()
        {
            double returnVar;

            var stopwatch = Stopwatch.StartNew();

            for (var i = 0; i < NumberTestsIterations; i++)
            {
                returnVar = Math.Sqrt(1568464648.234234);
            }

            stopwatch.Stop();
            Program.PrintElapsedTime(stopwatch, NumberTestsIterations, true);
        }

        // NOTE: Increased to 1000000 iterations. Time in milliseconds
        public static void AtanTest()
        {
            double returnVar;

            var stopwatch = Stopwatch.StartNew();

            for (var i = 0; i < NumberTestsIterations; i++)
            {
                returnVar = Math.Atan(1568464648.234234);
            }

            stopwatch.Stop();
            Program.PrintElapsedTime(stopwatch, NumberTestsIterations, true);
        }

        // NOTE: Increased to 1000000 iterations. Time in milliseconds
        public static void ExpTest()
        {
            double returnVar;

            var stopwatch = Stopwatch.StartNew();

            for (var i = 0; i < NumberTestsIterations; i++)
            {
                returnVar = Math.Exp(158.234234);
            }

            stopwatch.Stop();
            Program.PrintElapsedTime(stopwatch, NumberTestsIterations, true);
        }

        // NOTE: Increased to 1000000 iterations
        public static void RandomNumberTest()
        {
            int returnVar;

            var stopwatch = Stopwatch.StartNew();

            for (var i = 0; i < NumberTestsIterations; i++)
            {
                var randomize = new Random(DateTime.Now.Millisecond);
                returnVar = randomize.Next(256, 2560);
            }

            stopwatch.Stop();
            Program.PrintElapsedTime(stopwatch, NumberTestsIterations);
        }
    }
}
