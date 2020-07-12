using System;
using System.Diagnostics;
using System.IO;

namespace CSharp
{
    public class FileModule
    {
        private static readonly string BaseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        private static readonly string TestFilesDirectory = Path.Combine(BaseDirectory, "TestFiles");
        private static readonly string ReadTestFile = Path.Combine(BaseDirectory, "da51f72f-7804-40fe-bc66-8fc5418325fb_001.data");

        private const string TestFilePrefix = "testFile_";
        private const string TestFileExtension = ".txt";

        public static void ReadFile_AllText()
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

        public static void WriteFile_AllText()
        {
            var stopwatch = Stopwatch.StartNew();

            for (var i = 0; i < Program.Iterations; i++)
            {
                // TODO: WriteFile_AllText
            }

            stopwatch.Stop();
            Program.PrintElapsedTime(stopwatch);
        }

        public static void WriteFile_ByLine()
        {
            var stopwatch = Stopwatch.StartNew();

            for (var i = 0; i < Program.Iterations; i++)
            {
                // TODO: WriteFile_ByLine
            }

            stopwatch.Stop();
            Program.PrintElapsedTime(stopwatch);
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
            // TODO: Progress bar
            Console.WriteLine("Creating test files...");
            var testFileContent = File.ReadAllText(ReadTestFile);
            Directory.CreateDirectory(TestFilesDirectory);

            for (var i = 0; i < Program.Iterations; i++)
            {
                File.WriteAllText(Path.Combine(TestFilesDirectory, $"{TestFilePrefix}{i}{TestFileExtension}"), testFileContent);
            }
        }

        private static void DeleteTestFiles()
        {
            Console.WriteLine("Deleting test files...");
            Directory.Delete(TestFilesDirectory, true);
        }
    }
}
