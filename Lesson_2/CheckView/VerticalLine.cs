using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckView
{
    public class VerticalLine : Figure
    {
        int x;
        int yUp;
        int yDown;
        char sym;

        public VerticalLine(int _x, int _yUp, int _yDown, char _sym)
        {
            if (_yUp <= _yDown)
            {
                yUp = _yUp;
                yDown = _yDown;
            }
            else
            {
                yUp = _yDown;
                yDown = _yUp;
            }
            x = _x;
            sym = _sym;

            for (int i = yUp; i <= yDown; i++)
            {
                points.Add(new Point(x, i, sym));
            }
        }
    }
}
