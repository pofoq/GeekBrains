using System;
using System.Collections.Generic;
using System.Text;

namespace Temperature
{
    class Program
    {
        public enum TypeOfTemperature
        {
            Minimal,
            Maximal,
            Average
        }

        static void Main(string[] args)
        {
            double minT = TemperatureRequest(TypeOfTemperature.Minimal);
            double maxT = TemperatureRequest(TypeOfTemperature.Maximal);
            double avgT = (minT + maxT) / 2;

            Console.WriteLine($"Average temperature is {avgT}");

            int monthNum = CurrentMonth.Program.Main(null);

            List<CurrentMonth.Program.Month> l = new List<CurrentMonth.Program.Month>() 
            { 
                CurrentMonth.Program.Month.December, 
                CurrentMonth.Program.Month.January,
                CurrentMonth.Program.Month.February
            };

            if (l.Contains((CurrentMonth.Program.Month)monthNum) && avgT > 0)
                Console.WriteLine("«Дождливая зима»");

            Console.ReadLine();
        }

        public static double TemperatureRequest(TypeOfTemperature typeOfTemperature)
        {
            double dbl;
            ShowMsg(typeOfTemperature);
            while (!double.TryParse(Console.ReadLine().Replace('.', ','), out dbl))
            {
                ShowMsg(typeOfTemperature, true);
            }
            return dbl;
        }

        public static void ShowMsg(TypeOfTemperature typeOfTemperature, bool isRepeat = false)
        {
            StringBuilder builder = new StringBuilder("Please, enter ", 100);
            if (isRepeat)
                builder.Append("correct ");

            builder.Append($"{typeOfTemperature} temperature: ");

            Console.WriteLine(builder);
        }
    }
}
