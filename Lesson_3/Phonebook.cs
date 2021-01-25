using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_03
{
    public class Phonebook
    {
        string[,] phoneArray;

        public Phonebook(int countOfContacts)
        {
            phoneArray = new string[countOfContacts, 2];
        }

        // по задумке возвращает bool для проверки, добавился контакт или нет. 
        // На деле не использовал, но теоретически, могло бы пригодиться на будущее. 
        // Как минимум ошибку не выдаст
        public bool Add(int contactNumber, string name, string phone)
        {
            if (contactNumber < phoneArray.GetLength(0))
            {
                phoneArray[contactNumber, 0] = name;
                phoneArray[contactNumber, 1] = phone;
                return true;
            }
            else
                return false;
        }

        public void ShowAllContacts()
        {
            Console.Clear();
            int maxLength = 0;
            for (int y = 0; y < phoneArray.GetLength(0); y++)
            {
                Console.WriteLine(phoneArray[y, 0]);
                if (maxLength < phoneArray[y, 0].Length)
                    maxLength = phoneArray[y, 0].Length;
            }

            for (int y = 0; y < phoneArray.GetLength(0); y++)
            {
                Console.SetCursorPosition(maxLength + 3, y);
                Console.WriteLine(phoneArray[y, 1]);
            }
        }
    }
}
