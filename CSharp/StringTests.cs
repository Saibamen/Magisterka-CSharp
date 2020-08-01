using System;
using System.Diagnostics;
using System.Linq;

namespace CSharp
{
    public static class StringTests
    {
        // TODO: StringModule
        private const string TestString = "      ThisIsExample123StringToTestStringOperationsThisIsExample123StringToTestStringOperations      ";
        private const string TestStringWithoutSpaces = "ThisIsExample123StringToTestStringOperationsWoSpacThisIsExample123StringToTestStringOperationsWoSpac";

        // Wycinanie pierwszych 3 znaków, łączenie stringów

        // NOTE: Increased to 30000 iterations. Time in milliseconds
        public static void AscTest()
        {
            const int testIterations = 30000;
            int returnVar;

            var stopwatch = Stopwatch.StartNew();

            for (var i = 0; i < testIterations; i++)
            {
                returnVar = TestStringWithoutSpaces.First();
            }

            stopwatch.Stop();
            Program.PrintElapsedTime(stopwatch, testIterations, true);
        }

        private static int Asc(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return 0;
            }

            return (int) text.First();
        }

        private static string Mid(string text, int start, int length)
        {
            if (string.IsNullOrEmpty(text))
            {
                return "";
            }

            var part = text.Length < start ? "" : text.Substring(start - 1);
            return part.Length > length ? part.Substring(0, length) : part;
        }

        private static string Left(string text, int length)
        {
            if (string.IsNullOrEmpty(text))
            {
                return "";
            }

            var lengthSafe = Math.Min(text.Length, length);
            return text.Substring(0, lengthSafe);
        }

        private static string Right(string text, int length)
        {
            if (string.IsNullOrEmpty(text))
            {
                return "";
            }

            // index should be >= 0
            var indexSafe = Math.Max(0, text.Length - length);
            // ... and not more than text.Length
            indexSafe = Math.Min(indexSafe, text.Length);
            return text.Substring(indexSafe);
        }

        private static string Trim(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return "";
            }

            return text.Trim();
        }

        private static int Len(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return 0;
            }

            return text.Length;
        }

        private static string LCase(string text)
        {
            return text?.ToLower();
        }

        private static string UCase(string text)
        {
            return text?.ToUpper();
        }

        // TODO: val?
    }
}
