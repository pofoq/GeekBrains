using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            //int x1 = 1;
            //int y1 = 3;
            //char sym1 = '*';
            Point p1 = new Point
            {
                x = 1,
                y = 3,
                sym = '*'
            };

            p1.Draw();

            //int x2 = 4;
            //int y2 = 5;
            //char sym2 = '#';
            Point p2 = new Point();
            p2.x = 4;
            p2.y = 5;
            p2.sym = '#';

            p2.Draw();

            Point p3 = new Point(6, 9, '%');

            p3.Draw();

            Console.ReadLine();

        }
    }
}
