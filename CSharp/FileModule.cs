using System;
using System.Diagnostics;
using System.IO;

namespace CSharp
{
    public class FileModule
    {
        private static readonly string BaseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        private static readonly string ReadTestFile = $"{BaseDirectory}{Path.DirectorySeparatorChar}da51f72f-7804-40fe-bc66-8fc5418325fb_001.data";

        public static void ReadFile_ReadAllText()
        {
            var stopwatch = Stopwatch.StartNew();

            for (var i = 0; i < Program.Iterations; i++)
            {
                File.ReadAllText(ReadTestFile);
            }

            stopwatch.Stop();
            Program.PrintElapsedTime(stopwatch);
        }

        public static void ReadFile_ByLine()
        {
            var stopwatch = Stopwatch.StartNew();

            for (var i = 0; i < Program.Iterations; i++)
            {
                var fileStream = new FileStream(ReadTestFile, FileMode.Open);
                using var streamReader = new StreamReader(fileStream);
                streamReader.ReadLine();
            }

            stopwatch.Stop();
            Program.PrintElapsedTime(stopwatch);
        }
    }
}