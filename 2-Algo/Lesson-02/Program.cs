using System;

namespace Lesson_02
{
    class Program
    {
        static void Main(string[] args)
        {
            TestTask1();
            Console.ReadKey();

            Console.Clear();

            TestTask2();
            Console.ReadKey();
        }

        public static void TestTask2()
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Console.Write($"Поиск значения 8: {Finder.BinarySearch(arr, 8)}");
            Answer(7);
            Console.Write($"Поиск значения 8: {Finder.BinarySearch(arr, 3)}");
            Answer(2);
            Console.Write($"Поиск значения 8: {Finder.BinarySearch(arr, 0)}");
            Answer(-1);
        }

        public static void Answer(int res)
        {
            Answer($"{res}");
        }

        public static void Answer(string res)
        {
            ConsoleColor color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"\t{res}");
            Console.WriteLine();
            Console.ForegroundColor = color;
        }

        public static void TestTask1()
        {
            LinkedList list = new LinkedList(10);
            Console.Write($"Кол-во: {list.GetCount()}");
            Answer(1);
            Console.WriteLine($"Добавили элемент 20");
            list.AddNode(20);
            Console.WriteLine($"Добавили элемент 30");
            list.AddNode(30);
            Console.WriteLine($"Добавили элемент 40");
            list.AddNode(40);
            Console.WriteLine($"Добавили элемент 50");
            list.AddNode(50);
            Console.WriteLine();
            Console.Write($"Кол-во: {list.GetCount()}");
            Answer(5);
            Console.WriteLine($"Поиск несуществующего элемента 35");
            var node = list.FindNode(35); // несуществующий элемент
            if (node is null)
                Console.WriteLine($"Элемент не существует");
            else
                Console.WriteLine($"Элемент 35: {node.Value}");
            Console.WriteLine($"Поиск элемента 30");
            node = list.FindNode(30);
            Console.Write($"Элемент после элемента 30: {node.NextNode.Value}");
            Answer(40);
            Console.WriteLine($"Добавили элемент 35 после элемента 30");
            list.AddNodeAfter(node, 35);
            Console.Write($"Элемент после элемента 30: {node.NextNode.Value}");
            Answer(35);
            Console.Write($"Кол-во: {list.GetCount()}");
            Answer(6);
            Console.Write($"Элемент перед элементом 35: {list.FindNode(35).PrevNode.Value}");
            Answer(30);
            Console.WriteLine($"Удалили элемент 30");
            list.RemoveNode(node);
            Console.Write($"Элемент перед элементом 35: {list.FindNode(35).PrevNode.Value}");
            Answer(20);
            Console.Write($"Кол-во: {list.GetCount()}");
            Answer(5);
            Console.Write($"Первый элемент: {list.FirstNode.Value}");
            Answer(10);
            Console.WriteLine($"Удалили первый элемент по индексу");
            list.RemoveNode(0);
            Console.Write($"Кол-во: {list.GetCount()}");
            Answer(4);
            Console.Write($"Первый элемент: {list.FirstNode.Value}");
            Answer(20);
            Console.Write($"Последний элемент: {list.LastNode.Value}");
            Answer(50);
            Console.WriteLine($"Удалили последний элемент по индексу");
            list.RemoveNode(list.GetCount() - 1);
            Console.Write($"Кол-во: {list.GetCount()}");
            Answer(3);
            Console.WriteLine();
            Console.Write($"Последний элемент: {list.LastNode.Value}");
            Answer(40);
            Console.WriteLine($"Удалили последний");
            list.RemoveNode(list.LastNode);
            Console.WriteLine();
            Console.Write($"Кол-во: {list.GetCount()}");
            Answer(2);
            Console.Write($"Последний элемент: {list.LastNode.Value}");
            Answer(35);
            node = list.FirstNode;
            Console.Write($"Список оставшихся элементов: ");
            for (int i = 0; i < list.GetCount(); i++)
            {
                Console.Write(node.Value + " ");
                node = node.NextNode;
            }
            Answer("20 35");
        }
    }
}
