using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckView
{
    public class HorizontalLine : Figure
    {
        int xStart;
        int xEnd;
        int y;
        char sym;

        public HorizontalLine(int _xStart, int _xEnd, int _y, char _sym)
        {
            if (_xStart <= _xEnd)
            {
                xStart = _xStart;
                xEnd = _xEnd;
            }
            else
            {
                xStart = _xEnd;
                xEnd = _xStart;
            }
            y = _y;
            sym = _sym;

            for (int i = _xStart; i <= _xEnd; i++)
            {
                points.Add(new Point(i, y, sym));
            }
        }
    }
}
