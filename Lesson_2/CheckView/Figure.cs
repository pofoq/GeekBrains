using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckView
{
    public class Figure
    {
        protected List<Point> points = new List<Point>();

        public void Draw()
        {
            foreach (var p in points)
            {
                p.Draw();
            }
        }

        public void Draw(ConsoleColor consoleColor)
        {
            ConsoleColor defaultColor = Console.ForegroundColor;
            Console.ForegroundColor = consoleColor;
            Draw();
            Console.ForegroundColor = defaultColor;
        }
    }
}
