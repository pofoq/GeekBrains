using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_08
{
    public class MyElement
    {
        StreamReader reader;
        public int Value;
        public bool IsComplete;

        public MyElement(FileInfo file)
        {
            if (file.Exists)
            {
                reader = new StreamReader(file.OpenRead());
                if (int.TryParse(reader.ReadLine(), out Value))
                    IsComplete = false;
                else
                    Complete();
            }
            else
                Complete();
        }

        void Complete()
        {
            reader.Close();
            reader.Dispose();
            reader = null;
            IsComplete = true;
        }

        public bool Next()
        {
            string line;
            if ((line = reader.ReadLine()) is null)
            {
                Complete();
                return false;
            }
            else
            {
                Value = int.Parse(line);
                return true;
            }
        }
    }
}
