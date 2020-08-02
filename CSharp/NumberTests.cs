using System;
using System.Diagnostics;

namespace CSharp
{
    public static class NumberTests
    {
        private const int NumberTestsIterations = 1000000;
        // TODO: NumberTests

        // Operacje na liczbach całkowitych, zmiennoprzecinkowych, zaokrąglenia

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

        // NOTE: Increased to 1000000 iterations
        public static void AddIntTest()
        {
            double returnVar;

            var stopwatch = Stopwatch.StartNew();

            for (var i = 0; i < NumberTestsIterations; i++)
            {
                returnVar = Math.Sin(8546161887.15885);
            }

            stopwatch.Stop();
            Program.PrintElapsedTime(stopwatch, NumberTestsIterations, true);
        }
    }
}
