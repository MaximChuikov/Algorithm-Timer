using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Laboratornaya
{
    public static class Timer
    {
        public delegate void sort(int[] arr);
        public delegate double powing(double num, uint degree);

        static System.Diagnostics.Stopwatch clock = new();
        static Random rand = new Random();
        static List<string> strings = new List<string>();

        public static void Sorting(sort d)
        {
            var list = new List<double>();
            int[] experimentalArr;
            double[] timeEllapsed;
            for (int i = 2; i <= 2002; i++)
            {
                experimentalArr = new int[i];
                RandomFilling(experimentalArr);

                timeEllapsed = new double[5];
                for (int j = 0; j < timeEllapsed.Length; j++)
                    timeEllapsed[j] = SortTimering(d, experimentalArr.ToArray());

                ClearingData(ref timeEllapsed);
                list.Add(timeEllapsed.Average());
            }
            AddString(d.Method.Name, list.ToArray());
        }
        public static void Powing(powing p)
        {
            var list = new List<double>();
            double[] timeEllapsed;
            for (uint i = 0; i < 2000; i++)
            {
                timeEllapsed = new double[8];
                for (int j = 0; j < timeEllapsed.Length; j++)
                    timeEllapsed[j] = PowingTimering(p, i);

                ClearingData(ref timeEllapsed);
                list.Add(timeEllapsed.Average());
            }
            AddString(p.Method.Name, list.ToArray());
        }
        private static void ClearingData(ref double[] timeArr)
        {
            if (timeArr.Length <= 3)
                throw new Exception();

            const double deviasion = 1.8; //отклонение в X раз от среднего 2 мин. элементов
            Array.Sort(timeArr);
            var minAvg = (timeArr[0] + timeArr[1]) / 2;

            for (int i = timeArr.Length - 1; i >= 2; i--)
            {
                if (!(timeArr[i] > deviasion * minAvg))
                {
                    if (i < timeArr.Length - 1)
                        timeArr = timeArr.SkipLast(timeArr.Length - 1 - i).ToArray();
                        break;
                }
            }
            
            if (timeArr.Length <= 2)
                throw new Exception("Very corrupted data");
        }
        private static double SortTimering(sort del, int[] arr)
        {
            clock.Reset();
            clock.Start();
            del(arr);
            clock.Stop();
            return clock.Elapsed.TotalMilliseconds;
        }
        private static double PowingTimering(powing p, uint degree)
        {
            const double x = 1.1;
            clock.Reset();
            clock.Start();
            p(x, degree);
            clock.Stop();
            return clock.Elapsed.TotalMilliseconds;
        }
            
        static void RandomFilling(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
                array[i] = rand.Next();
        }
        static void AddString(string name, double[] timeArr) => strings.Add(name + ';' + string.Join(';', timeArr));
        public static void CreateDoc(string nameDoc)
        {
            File.WriteAllLines(Environment.CurrentDirectory + $"\\{nameDoc}.csv", strings);
            ClearNotes();
        }
        private static void ClearNotes() => strings.Clear();
    }
}
