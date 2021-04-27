using System;

namespace Lesson_03
{
    class Program
    {

        static void Main(string[] args)
        {
            // Задание 1
            int y, x;
            y = GetInt("Rows");
            x = GetInt("Columns");

            Diagonal diagonal = new Diagonal(y, x);
            diagonal.ShowArray();
            NextMsg();

            // Задание 2
            x = GetInt("Contacts");
            Phonebook phonebook = new Phonebook(x);
            for (int i = 0; i < x; i++)
            {
                Console.Write($"Enter Contact Name {i + 1}: ");
                string name = Console.ReadLine().Trim();
                Console.Write($"Enter Contact Phone {i + 1}: ");
                string phone = Console.ReadLine().Trim();
                phonebook.Add(i, name, phone);
            }
            phonebook.ShowAllContacts();
            NextMsg();

            // Задание 3
            Console.Write("Enter a string: ");
            string str = Console.ReadLine();
            Console.WriteLine(Revers.GetReversString_1(str));
            Console.WriteLine(Revers.GetReversString_2(str));
            NextMsg();

            // Задание 4
            WarShip warShip = new WarShip();
            Console.WriteLine("WarShip Field is created. Click any key to see it.");
            Console.ReadKey();
            Console.Clear();
            warShip.DrawField();
            warShip.DrawShips();
            NextMsg();

            // Повторяющийся код
            void NextMsg()
            {
                Console.WriteLine("Click any key to continue the program.");
                Console.ReadKey();
                Console.Clear();
            }

            int GetInt( string parameterName = "")
            {
                int num;
                while (true)
                {
                    Console.Write($"Please, enter a {parameterName} number: ");
                    int.TryParse(Console.ReadLine(), out num);
                    if (num > 0)
                        return num;
                }
            }

            Console.ReadKey();
        }
    }
}
