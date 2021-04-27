using System;
using System.IO;

namespace FileReadesLibrary
{
    public class Log
    {
        public string logFile { get; }
        public string filesDone { get; }

        public Log(string catalogPath)
        {
            logFile = Path.Combine(catalogPath, "_log.log");
            filesDone = Path.Combine(catalogPath, "_myFiles.json");
        }

        void Add(string to, string txt)
        {
            File.AppendAllText(to, txt + Environment.NewLine);
        }

        public void Add(MyFile myFile)
        {
            Add(filesDone, myFile.GetJson());
        }

        public void Add(string txt)
        {
            Add(logFile, txt);
        }
    }
}
