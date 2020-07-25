using System;
using System.Diagnostics;
using System.IO;

namespace CSharp
{
    public static class FileTests
    {
        private static readonly string BaseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        private static readonly string TestFilesDirectory = Path.Combine(BaseDirectory, "TestFiles");
        private static readonly string ReadTestFile = Path.Combine(BaseDirectory, "da51f72f-7804-40fe-bc66-8fc5418325fb_001.data");

        private const string TestFilePrefix = "testFile_";
        private const string TestFileExtension = ".txt";

        public static void DeleteTestFiles()
        {
            if (!Directory.Exists(TestFilesDirectory))
            {
                return;
            }

            Console.WriteLine("Deleting test files...");
            Directory.Delete(TestFilesDirectory, true);
        }

        public static void ReadFile_AllText()
        {
            string returnVar;

            var stopwatch = Stopwatch.StartNew();

            for (var i = 0; i < Program.Iterations; i++)
            {
                returnVar = File.ReadAllText(ReadTestFile);
            }

            stopwatch.Stop();
            Program.PrintElapsedTime(stopwatch);
        }

        // NOTE: Decreased to 25 iterations
        public static void ReadFile_ByLine()
        {
            const int iterations = 25;
            string returnVar = null;

            var stopwatch = Stopwatch.StartNew();

            for (var i = 0; i < iterations; i++)
            {
                string line;
                using var streamReader = new StreamReader(ReadTestFile);

                while ((line = streamReader.ReadLine()) != null)
                {
                    returnVar += line;
                }
            }

            stopwatch.Stop();
            Program.PrintElapsedTime(stopwatch, iterations);
        }

        public static void WriteFile_AllText()
        {
            var testFileContent = File.ReadAllText(ReadTestFile);
            Directory.CreateDirectory(TestFilesDirectory);

            var stopwatch = Stopwatch.StartNew();

            for (var i = 0; i < Program.Iterations; i++)
            {
                File.WriteAllText(Path.Combine(TestFilesDirectory, $"{TestFilePrefix}{i}_WriteAllText{TestFileExtension}"), testFileContent);
            }

            stopwatch.Stop();
            Program.PrintElapsedTime(stopwatch);

            DeleteTestFiles();
        }

        public static void WriteFile_ByLine()
        {
            var testFileLines = File.ReadAllLines(ReadTestFile);
            Directory.CreateDirectory(TestFilesDirectory);

            var stopwatch = Stopwatch.StartNew();

            for (var i = 0; i < Program.Iterations; i++)
            {
                File.WriteAllLines(Path.Combine(TestFilesDirectory, $"{TestFilePrefix}{i}_WriteAllLines{TestFileExtension}"), testFileLines);
            }

            stopwatch.Stop();
            Program.PrintElapsedTime(stopwatch);

            DeleteTestFiles();
        }

        public static void RenameFiles()
        {
            CreateTestFiles();

            var stopwatch = Stopwatch.StartNew();

            for (var i = 0; i < Program.Iterations; i++)
            {
                File.Move(Path.Combine(TestFilesDirectory, $"{TestFilePrefix}{i}{TestFileExtension}"), Path.Combine(TestFilesDirectory, $"{TestFilePrefix}{i}_renamed{TestFileExtension}"));
            }

            stopwatch.Stop();
            Program.PrintElapsedTime(stopwatch);

            DeleteTestFiles();
        }

        public static void CopyFiles()
        {
            CreateTestFiles();
            var copyDirectory = Path.Combine(TestFilesDirectory, "CopyDirectory");
            Directory.CreateDirectory(copyDirectory);

            var stopwatch = Stopwatch.StartNew();

            for (var i = 0; i < Program.Iterations; i++)
            {
                File.Copy(Path.Combine(TestFilesDirectory, $"{TestFilePrefix}{i}{TestFileExtension}"), Path.Combine(copyDirectory, $"{TestFilePrefix}{i}_copied{TestFileExtension}"));
            }

            stopwatch.Stop();
            Program.PrintElapsedTime(stopwatch);

            DeleteTestFiles();
        }

        public static void DeleteFiles()
        {
            CreateTestFiles();

            var stopwatch = Stopwatch.StartNew();

            for (var i = 0; i < Program.Iterations; i++)
            {
                File.Delete(Path.Combine(TestFilesDirectory, $"{TestFilePrefix}{i}{TestFileExtension}"));
            }

            stopwatch.Stop();
            Program.PrintElapsedTime(stopwatch);

            DeleteTestFiles();
        }

        private static void CreateTestFiles()
        {
            Console.WriteLine("Creating test files...");
            var testFileContent = File.ReadAllText(ReadTestFile);
            Directory.CreateDirectory(TestFilesDirectory);

            for (var i = 0; i < Program.Iterations; i++)
            {
                File.WriteAllText(Path.Combine(TestFilesDirectory, $"{TestFilePrefix}{i}{TestFileExtension}"), testFileContent);

                ClearCurrentConsoleLine();
                Console.Write($"{i + 1} of {Program.Iterations}");
            }

            Console.WriteLine();
        }

        private static void ClearCurrentConsoleLine()
        {
            var currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }
    }
}
