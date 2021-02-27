using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace lesson03
{
    public struct PointStruct
    {
        public int X;
        public int Y;
    }

    public class PointClass
	{
		public int X;
		public int Y;

        public static PointClass[] arr = new PointClass[] {
            new PointClass{X=1,Y=2},
            new PointClass{X=35,Y=32},
            new PointClass{X=74,Y=18},
            new PointClass{X=25,Y=67},
            new PointClass{X=35,Y=4},
            new PointClass{X=6,Y=43},
            new PointClass{X=16,Y=8},
            new PointClass{X=27,Y=9},
            };

        public static PointStruct[] arrStruct = new PointStruct[] {
            new PointStruct{X=1,Y=2},
            new PointStruct{X=35,Y=32},
            new PointStruct{X=74,Y=18},
            new PointStruct{X=25,Y=67},
            new PointStruct{X=35,Y=4},
            new PointStruct{X=6,Y=43},
            new PointStruct{X=16,Y=8},
            new PointStruct{X=27,Y=9},
            };


        // TASK 1
        [Benchmark]
        public void Task1_ClassFloat()
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                PointDistance(arr[i], arr[i++]);
            }
        }

        public static float PointDistance(PointClass pointOne, PointClass pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }

        // TASK 2
        [Benchmark]
        public void Task2_StructFloat()
        {
            for (int i = 0; i < arrStruct.Length - 1; i++)
            {
                PointDistance(arrStruct[i], arrStruct[i++]);
            }
        }

        // TASK 3
        [Benchmark]
        public void Task3_StructDouble()
        {
            for (int i = 0; i < arrStruct.Length - 1; i++)
            {
                PointDistanceDouble(arrStruct[i], arrStruct[i++]);
            }
        }

        // TASK 4
        [Benchmark]
        public void Task4_StructFloatShort()
        {
            for (int i = 0; i < arrStruct.Length - 1; i++)
            {
                PointDistanceShort(arrStruct[i], arrStruct[i++]);
            }
        }

        // Пример расчёта дистанции:
        public static float PointDistance(PointStruct pointOne, PointStruct pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }

        //Тот же пример, но уже без вычисления квадратного корня в конце:
        public static float PointDistanceShort(PointStruct pointOne, PointStruct pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return (x * x) + (y * y);
        }

        public static double PointDistanceDouble(PointStruct pointOne, PointStruct pointTwo)
        {
            double x = pointOne.X - pointTwo.X;
            double y = pointOne.Y - pointTwo.Y;
            return Math.Sqrt((x * x) + (y * y));
        }
    }
}
