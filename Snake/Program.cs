using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetBufferSize(80, 25);

            // Рамка
            Walls walls = new Walls(80, 25);
            walls.Draw();

            // Отрисовка точек
            Point p = new Point(4, 5, '*');
            Snake snake = new Snake(p, 4, Direction.Right);
            snake.Draw();

            FoodCreator foodCreator = new FoodCreator(80, 25, '$');
            Point food = foodCreator.CreateFood();
            food.Draw();

            while (true)
            {
                if(walls.IsHit(snake) || snake.IsHitTail())
                {
                    break;
                }
                if (snake.Eat(food))
                {
                    food = foodCreator.CreateFood();
                    food.Draw();
                }
                else
                {
                    snake.Move();
                }

                Thread.Sleep(100);

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandleKey(key.Key);
                }
            }

            //Point p1 = new Point
            //{
            //    x = 1,
            //    y = 1,
            //    sym = '*'
            //};
            //p1.Draw();

            //Point p2 = new Point();
            //p2.x = 2;
            //p2.y = 2;
            //p2.sym = '#';
            //p2.Draw();

            //Point p3 = new Point(3, 3, '%');
            //p3.Draw();

            //HorizontalLine hLine = new HorizontalLine(5, 10, 8, '+');
            //hLine.Draw();

            //VerticalLine vLine = new VerticalLine(4, 9, 6, '$');
            //vLine.Draw();

            Console.ReadLine();

        }
    }
}
