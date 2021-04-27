using System;
using System.Text;

namespace CheckView
{
    class Program
    {
        static void Main(string[] args)
        {
            Check check = new Check(40, 1);

            Console.Write("Номер чека: ");
            check.CheckNum = Console.ReadLine();
            Console.Write("Название компании: ");
            check.CompanyName = Console.ReadLine();
            Console.Write("Фамилия продавца: ");
            check.SellerName = Console.ReadLine();

            while (true)
            {
                string prodName;
                decimal price = 0;

                Console.Write($"Введите наименование товара № {check.ProductCount + 1}: ");
                prodName = Console.ReadLine();

                while (true)
                {
                    Console.Write($"Введите стоимость товара № {check.ProductCount + 1}: ");
                    if (decimal.TryParse(Console.ReadLine().Replace('.', ','), out price))
                        break;
                }

                check.AddProduct(prodName, price);

                Console.WriteLine($"Завершить наполнение товара, нажми \t\"q\"{Environment.NewLine}Добавить новый товар, нажми\t\"Enter\"");
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.Q)
                    break;
            }

            check.Draw();

            Console.ReadLine();
        }
    }
}
