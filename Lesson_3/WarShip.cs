using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_03
{
    public class WarShip
    {
        int _fieldLength;
        int[,] field;
        List<Ship> ships;
        byte[] noShip = System.Text.Encoding.Default.GetBytes("X");

        public WarShip()
        {
            ships = new List<Ship>();
            int fieldLength = 10;
            _fieldLength = fieldLength;
            field = new int[_fieldLength, _fieldLength];

            for (int y = 0; y < field.GetLength(0); y++)
            {
                for (int x = 0; x < field.GetLength(1); x++)
                {
                    field[y, x] = 'O';
                }
            }
            Ship ship1 = new Ship(new Point(2, 2, 'X'), 3, Direction.Vertical);
            Ship ship2 = new Ship(new Point(5, 2, 'X'), 4, Direction.Horizontal);
            Ship ship3 = new Ship(new Point(4, 1, 'X'), 1, Direction.Vertical);
            Ship ship4 = new Ship(new Point(6, 6, 'X'), 2, Direction.Vertical);
            Ship ship5 = new Ship(new Point(9, 5, 'X'), 5, Direction.Vertical);

            ships.Add(ship1);
            ships.Add(ship2);
            ships.Add(ship3);
            ships.Add(ship4);
            ships.Add(ship5);
        }

        public void DrawField()
        {
            for (int y = 0; y < field.GetLength(0); y++)
            {
                for (int x = 0; x < field.GetLength(1); x++)
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write(char.ConvertFromUtf32(field[y, x]));
                }
            }
            Console.SetCursorPosition(0, _fieldLength + 2);
        }

        public void DrawShips()
        {
            foreach (var s in ships)
            {
                s.Draw();
            }
            Console.SetCursorPosition(0, _fieldLength + 2);
        }
    }

    enum Direction
    {
        Horizontal,
        Vertical
    }

    class Ship
    {
        List<Point> points;

        public Ship(Point startPoint, int shipLength, Direction direction)
        {
            points = new List<Point>();
            points.Add(startPoint);
            for (int i = 0; i < shipLength; i++)
            {
                points.Add(startPoint.GetNext(direction));
            }
        }

        public void Draw()
        {
            foreach(var p in points)
            {
                p.Draw();
            }
        }
    }

    class Point
    {
        int _x, _y;
        char _sym;
        public Point(int x, int y, char sym)
        {
            _x = x;
            _y = y;
            _sym = sym;
        }

        public Point GetNext(Direction direction)
        {
            if (direction == Direction.Horizontal)
            {
                return new Point(_x + 1, _y, _sym);
            }
            else
            {
                return new Point(_x, _y + 1, _sym);
            }
        }

        public void Draw()
        {
            Console.SetCursorPosition(_x, _y);
            Console.Write(_sym);
        }
    }
}
