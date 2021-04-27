using System;
using FileReadesLibrary;

namespace NewFileReader
{
    class Program
    {
        static void Main(string[] args)
        {
            Catalog catalog = new Catalog(Catalog.GetDirPath());
            Log log = new Log(catalog.folderPath);
            catalog.CheckDoneFiles(log.filesDone);
            while (true)
            {
                catalog.StartRead();
            }
        }
    }
}
