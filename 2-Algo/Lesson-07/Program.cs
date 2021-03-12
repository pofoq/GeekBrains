using System;

namespace Lesson_07
{
    class Program
    {
        static void Main(string[] args)
        {
            Field field = new Field(2, 2);
            Console.WriteLine($"Count Steps: {field.CountSteps()}");
            Print(2);
            field = new Field(2, 3);
            Console.WriteLine($"Count Steps: {field.CountSteps()}");
            Print(3);
            field = new Field(3, 3);
            Console.WriteLine($"Count Steps: {field.CountSteps()}");
            Print(6);
            field = new Field(4, 4);
            Console.WriteLine($"Count Steps: {field.CountSteps()}");
            Print(20);
            field = new Field(3, 4);
            Console.WriteLine($"Count Steps: {field.CountSteps()}");
            Print(10);
            field = new Field(6, 4);
            Console.WriteLine($"Count Steps: {field.CountSteps()}");
            Print(56);
            field = new Field(4, 8);
            Console.WriteLine($"Count Steps: {field.CountSteps()}");
            Print(120);
        }

        static void Print(int res)
        {
            ConsoleColor color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Expected: {res}");
            Console.ForegroundColor = color;
        }
    }

    class Field
    {
        int _width;
        int _height;

        public Field(int width, int height)
        {
            _width = width;
            _height = height;
        }

        public int CountSteps() => CountSteps(1, 1);

        private int CountSteps(int w, int h)
        {
            if (w == _width && h == _height)
                return 1;
            if (w > _width || h > _height)
                return 0;
            return CountSteps(w + 1, h) + CountSteps(w, h + 1);
        }
    }
}
