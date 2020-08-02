using System;
using System.Diagnostics;

namespace CSharp
{
    public static class NumberTests
    {
        // TODO: NumberTests

        // Operacje na liczbach całkowitych, zmiennoprzecinkowych, zaokrąglenia

        // NOTE: Increased to 32000 iterations. Time in milliseconds
        public static void IntTest()
        {
            const int testIterations = 32000;
            int returnVar;

            var stopwatch = Stopwatch.StartNew();

            for (var i = 0; i < testIterations; i++)
            {
                returnVar = (int) Math.Floor(123456789.987654321);
            }

            stopwatch.Stop();
            Program.PrintElapsedTime(stopwatch, testIterations, true);
        }
    }
}
