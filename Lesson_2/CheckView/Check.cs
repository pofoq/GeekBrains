using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckView
{
    public class Check
    {
        int width;
        int xMargin;
        int yMargin;
        int productCount = 0;

        string companyName;
        string checkNum;
        string sellerName;

        Dictionary<int, string> productName = new Dictionary<int, string>();
        Dictionary<int, decimal> productPrice = new Dictionary<int, decimal>();

        public string CompanyName { set { companyName = value; } }
        public string CheckNum { set { checkNum = value; } }
        public string SellerName { set { sellerName = value; } }
        public int ProductCount { get { return productCount; } set { productCount = value; } }

        public Check(int _width, int _xMargin, int _yMargin)
        {
            width = _width;
            xMargin = _xMargin + 3;
            yMargin = _yMargin + 3;
        }

        public Check(int _width, int _margin)
        {
            width = _width;
            xMargin = _margin + 2;
            yMargin = _margin + 2;
        }

        public void AddProduct(string name, decimal price)
        {
            productName.Add(++productCount, name);
            productPrice.Add(productCount, price);
        }

        public void Draw()
        {
            Console.Clear();
            int y = 3;
            decimal sum = 0;

            WriteLine(companyName, ref y, Align.Center);
            WriteLine($"Чек № {checkNum}", ref y, Align.Center);
            //WriteLine($"Кассир: {sellerName}", ref y, Align.Center);
            for (int i = 1; i <= productName.Count; i++)
            {
                WriteLine($"{i}. {productName[i]}", ref y, Align.Left);
                WriteLine($"Стоимость...{productPrice[i]:0.00}", ref y, Align.Right);
            }
            StringBuilder builder = new StringBuilder(width);
            for(int i = 0; i < width; i++)
            {
                builder.Append('=');
            }
            WriteLine(builder.ToString(), ref y, Align.Left);
            foreach(var d in productPrice)
            {
                sum += d.Value;
            }
            WriteLine($"ИТОГО: {sum:0.00}", ref y, Align.Right);
            WriteLine($"{DateTime.Now:dd.MM.yyyy HH:mm:ss}", ref y, Align.Left);
            WriteLine($"Кассир: {sellerName}", ref y, Align.Right);

            Figure up = new HorizontalLine(1, width + xMargin * 2 - 2, 1, '*');
            Figure down = new HorizontalLine(1, width + xMargin * 2 - 2, y + 1, '*');
            Figure left = new VerticalLine(1, 1, y + 1, '*');
            Figure right = new VerticalLine(width + xMargin * 2 - 2, 1, y + 1, '*');
            up.Draw();
            down.Draw();
            left.Draw();
            right.Draw();

            //Console.SetBufferSize(width + 4 + xMargin * 2, y + 2 + yMargin);
        }

        enum Align : sbyte
        {
            Center,
            Left,
            Right
        }

        void WriteLine(string str, ref int lineNum, Align align)
        {
            int xStart = xMargin;
            int yCount = (int)Math.Ceiling((str.Length * 1.00M / width));
            if (align == Align.Center)
            {
                xStart = (width - (str.Length % width)) / 2 + xMargin;
            }
            else if (align == Align.Right)
            {
                xStart = width + xMargin - str.Length;
            }

            for (int i = 0; i < yCount - 1; i++)
            {
                Console.SetCursorPosition(xMargin, lineNum++);
                Console.Write(str.Substring(width * i, width));
            }

            Console.SetCursorPosition(xStart, lineNum++);
            Console.Write(str.Substring(width * (yCount - 1)));
        }
    }
}
