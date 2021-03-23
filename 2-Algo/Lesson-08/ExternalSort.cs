using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lesson_08
{
    public static class ExternalSort
    {
        public static string TempPath = System.IO.Path.Combine(AppContext.BaseDirectory, "_temp");
        static string outputFile = System.IO.Path.Combine(TempPath, "output.txt");
        static List<FileInfo> files;

        public static FileInfo Sort(string inputFilePath, int maxLengthOfElementsInFile = 100)
        {
            // check output directory
            DirectoryInfo directory = new DirectoryInfo(TempPath);
            if (directory.Exists)
            {
                foreach (var file in directory.GetFiles())
                    file.Delete();
            }
            else
                directory.Create();

            // check input file
            FileInfo inputFile = inputFilePath is null ? null : new FileInfo(inputFilePath);
            if (inputFile is null)
                inputFile = CreateTestFile();
            else if (!inputFile.Exists)
                return null;

            SplitFile(inputFile, maxLengthOfElementsInFile);

            if (files is null || files.Count == 0)
                return null;

            foreach (var file in files)
            {
                SortInFile(file);
            }

            MergeFiles(files);

            return new FileInfo(outputFile);
        }

        static FileInfo CreateTestFile()
        {
            int[] arr = new int[] { 1, 5, 9, 7, 3, 6, 8, 4, 2, 55, 99, 77, 33, 66, 88, 22, 11, 44, 10, 50, 90, 30, 80, 20, 70, 40 };
            FileInfo file = new FileInfo(Path.Combine(ExternalSort.TempPath, "defaultTestFile.txt"));
            if (file.Exists)
                file.Delete();
            using (StreamWriter writer = new StreamWriter(file.OpenWrite()))
            {
                foreach (var el in arr)
                    writer.WriteLine(el);
            }
            return file;
        }

        static void MergeFiles(List<FileInfo> files)
        {
            List<MyElement> elements = new List<MyElement>();
            foreach (FileInfo file in files)
            {
                MyElement element = new MyElement(file);
                if (!element.IsComplete)
                    elements.Add(element);
            }
            if (elements.Count == 0)
                return;
            using (StreamWriter writer = new StreamWriter(outputFile))
            {
                while (elements.Count > 0)
                {
                    var min = GetMinElement(elements);
                    if (min is null)
                        break;
                    writer.WriteLine(min.Value);
                    if (!min.Next())
                        elements.Remove(min);
                }
            }
        }

        static MyElement GetMinElement(List<MyElement> elements)
        {
            if (elements is null || elements.Count == 0)
                return null;

            MyElement min = elements[0];

            for (int i = 1; i < elements.Count; i++)
            {
                var temp = elements[i];
                if (min.Value > temp.Value)
                    min = temp;
            }
            return min;
        }

        static void SplitFile(FileInfo inputFile, int maxLength)
        {
            files = new List<FileInfo>();

            using (StreamReader reader = new StreamReader(inputFile.OpenRead()))
            {
                string line;
                int num = maxLength;
                int fileNum = 0;
                StreamWriter writer = null;
                FileInfo file = null;
                while ((line = reader.ReadLine()) != null)
                {
                    num++;
                    if (num > maxLength)
                    {
                        num = 1;
                        if(writer != null)
                        {
                            writer.Flush();
                            writer.Close();
                            writer.Dispose();
                        }
                        fileNum++;
                        file = new FileInfo(System.IO.Path.Combine(TempPath, $"splitedFile_{fileNum}.txt"));
                        files.Add(file);
                        writer = new StreamWriter(file.OpenWrite());
                    }
                    writer.WriteLine(line);
                }
                writer.Flush();
                writer.Close();
                writer.Dispose();
                //files.Add(file);
            }
        }

        public static int[] GetArrayFromFile(FileInfo file)
        {
            if (!file.Exists)
                return null;
            using (StreamReader reader = new StreamReader(file.OpenRead()))
            {
                string line;
                List<int> list = new List<int>();
                while ((line = reader.ReadLine()) != null)
                {
                    if (int.TryParse(line, out int res))
                        list.Add(res);
                }
                return list.ToArray();
            }
        }

        static void SortInFile(FileInfo file)
        {
            int[] arr = GetArrayFromFile(file);
            QuickSort.Sort(arr, 0, arr.Length - 1);
            file.Delete();
            StreamWriter writer = new StreamWriter(file.FullName);
            foreach (int el in arr)
            {
                writer.WriteLine(el);
            }
            writer.Flush();
            writer.Close();
            writer.Dispose();
        }

        public static bool IsSorted(FileInfo file, out string statusText)
        {
            if (!file.Exists)
            {
                statusText = "File is not exists";
                return false;
            }
            else
            {
                using (StreamReader reader = new StreamReader(file.OpenRead()))
                {
                    int? prev = null;
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (int.TryParse(line, out int next))
                            if (prev is null)
                                prev = next;
                            else
                            {
                                if (prev <= next)
                                    prev = next;
                                else
                                {
                                    statusText = $"Not sorted. {prev}(prev) > {next}(next)";
                                    return false;
                                }
                            }
                    }
                }
                statusText = "SORTED";
                return true;
            }
        }
    }
}
