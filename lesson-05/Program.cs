using System;
using System.IO;

namespace lesson_05
{
    class Program
    {
        static void Main(string[] args)
        {
            string txtFile = "txtFile.txt";
            string binFile = "binFile.bin";

            //task 1
            Console.WriteLine("task 1 - Сохранение данных в текстовый файл");
            Console.WriteLine();
            MyFile.WriteTo(txtFile);
            NextTask();

            //task 2
            StartTime.Write();
            NextTask();

            //task 3
            MyFile.WriteBinaryTo(binFile);
            NextTask();

            //task 4
            Console.WriteLine("Введите путь к каталогу, чтобы отобразить его дерево: ");
            string folderPath = Console.ReadLine();
            Console.WriteLine("Введите название файла для сохранения дерева каталогов: ");
            MyDirectory dir = new MyDirectory(folderPath, Console.ReadLine());
            dir.GetDirsRecurs();
            dir.Show();
            NextTask();

            //task 5
            ToDoList toDoList = new ToDoList();
            toDoList.Run();
            NextTask();
        }

        static void NextTask()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
