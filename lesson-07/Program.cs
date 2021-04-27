using System;
using System.IO;

namespace FileReader
{
    class Program
    {
        /// <summary>
        /// Задание на декомпозицию:
        /// У вас ест файловый каталог, в который ежедневно поступают новые файлы, хранятся там 10 дней и потом удаляются.
        /// Нужно спроектировать приложение, которое бы читало файлы, сохраняло информацию о прочитанных в текстовый файл.
        /// Так же необходимо избежать повторной обработки уже обработанных файлов.
        /// Цель задачи: верно выделить необходимые классы и методы. "Спроектировать архитектуру приложения"
        /// </summary>
        static void Main()
        {
            Console.Title = "File Reader";
            Catalog catalog = new Catalog(Catalog.GetDirPath()); // запросить путь к папке с файлами
            log = new Log(catalog.folderPath);
            Console.Clear();
            Console.WriteLine($"Log Path: {log.logFile}");
            Console.WriteLine();
            Console.WriteLine("Start file reader...");
            Console.WriteLine();
            catalog.CheckDoneFiles(log.filesDone);
            while (true)
            {
                catalog.StartRead();
            }

            Console.ReadKey();
        }

        public static Log log;

    }
}
