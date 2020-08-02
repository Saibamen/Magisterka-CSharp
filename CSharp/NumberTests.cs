using System;
using System.Diagnostics;

namespace CSharp
{
    public static class NumberTests
    {
        // TODO: NumberTests

        // Operacje na liczbach całkowitych, zmiennoprzecinkowych, zaokrąglenia

        // NOTE: Increased to 1000000 iterations. Time in milliseconds
        public static void IntTest()
        {
            const int testIterations = 1000000;
            int returnVar;

            var stopwatch = Stopwatch.StartNew();

            for (var i = 0; i < testIterations; i++)
            {
                returnVar = (int) Math.Floor(32000.9876545569);
            }

            stopwatch.Stop();
            Program.PrintElapsedTime(stopwatch, testIterations, true);
        }

        // NOTE: Increased to 1000000 iterations. Time in milliseconds
        public static void RoundDecimalPlacesTest()
        {
            const int testIterations = 1000000;
            double returnVar;

            var stopwatch = Stopwatch.StartNew();

            for (var i = 0; i < testIterations; i++)
            {
                returnVar = Math.Round(32000.9876545569, 3);
            }

            stopwatch.Stop();
            Program.PrintElapsedTime(stopwatch, testIterations);
        }
    }
}
