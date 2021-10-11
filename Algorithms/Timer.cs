using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using GraphLibrary;

namespace Laboratornaya
{
    public static class Timer
    {
        public delegate void sort(int[] arr);
        public delegate double powing(double num, uint degree);
        public delegate long vector(int[] arr);

        static System.Diagnostics.Stopwatch clock = new();
        static readonly Random rand = new ();
        static readonly List<string> strings = new();

        public static void Sort(sort d)
        {
            var list = new List<double>();
            int[] experimentalArr;
            double[] timeEllapsed;
            for (int i = 2; i < 2002; i++)
            {
                experimentalArr = new int[i];
                RandomFilling(experimentalArr);

                timeEllapsed = new double[5];
                for (int j = 0; j < timeEllapsed.Length; j++)
                {
                    var arr = experimentalArr.ToArray();
                    timeEllapsed[j] = Timering(() => d(arr));
                }
                ClearingData(ref timeEllapsed);
                list.Add(timeEllapsed.Average());
            }
            AddString(d.Method.Name, list.ToArray());
        }
        public static void Bogosort()
        {
            var list = new List<double>();
            int[] arr;
            var sort = new Sort();
            for (int i = 2; i <= 11; i++)
            {
                Console.WriteLine("Bogosort " + i);
                arr = new int[i];
                RandomFilling(arr);
                list.Add(Timering(() => sort.BogoSort(arr)));
            }
            AddString("Bogosort", list.ToArray());
        }
        public static void Vector(vector d)
        {
            var list = new List<double>();
            int[] experimentalArr;
            double[] timeEllapsed;
            for (int i = 1; i <= 20001; i++)
            {
                experimentalArr = new int[i];
                RandomFilling(experimentalArr);

                timeEllapsed = new double[5];
                for (int j = 0; j < timeEllapsed.Length; j++)
                {
                    var arr = experimentalArr.ToArray();
                    timeEllapsed[j] = Timering(() => d(arr));
                }

                ClearingData(ref timeEllapsed);
                list.Add(timeEllapsed.Average());
            }
            AddString(d.Method.Name, list.ToArray());
        }
        public static void Pow(powing p)
        {
            const double x = 1.1;

            var list = new List<double>();
            double[] timeEllapsed;
            for (uint i = 0; i < 2000; i++)
            {
                timeEllapsed = new double[8];
                for (int j = 0; j < timeEllapsed.Length; j++)
                    timeEllapsed[j] = Timering(() => p(x, i));

                ClearingData(ref timeEllapsed);
                list.Add(timeEllapsed.Average());
            }
            AddString(p.Method.Name, list.ToArray());
        }
        public static void Matrix()
        {
            var list = new List<double>();
            double[] timeEllapsed;
            for (uint i = 2; i <= 202; i++)
            {
                timeEllapsed = new double[5];
                for (int j = 0; j < timeEllapsed.Length; j++)
                {
                    var a = new Matrix(i);
                    var b = new Matrix(i);
                    timeEllapsed[j] = Timering(() => { var g = a * b; });
                }

                ClearingData(ref timeEllapsed);
                list.Add(timeEllapsed.Average());
            }
            AddString("Multing Matrix", list.ToArray());
        }
        public static void Daekstra()
        {
            var list = new List<double>();
            double[] timeEllapsed;
            var graph = new GraphAlgorithm();
            for (uint i = 2; i < 2002; i++)
            {
                timeEllapsed = new double[6];
                for (int j = 0; j < timeEllapsed.Length; j++)
                {
                    graph.CreateGraph(i, 2, out Vertex a, out Vertex b);
                    timeEllapsed[j] = Timering(() => graph.AlgorithDeikstra(a, b));
                }

                ClearingData(ref timeEllapsed);
                list.Add(timeEllapsed.Average());
            }
            AddString("Deykstra", list.ToArray());
        }
        public static void Backpack()
        {
            var list = new List<double>();
            double[] timeEllapsed;
            for (uint i = 2; i <= 27; i++)
            {
                Tuple<int, int>[] weightCost = new Tuple<int, int>[i];
                RandomFillingThings(weightCost);

                timeEllapsed = new double[5];
                for (int j = 0; j < timeEllapsed.Length; j++)
                    timeEllapsed[j] = Timering(() => BackPackTask.BackPack(weightCost.ToArray(), rand.Next(90000, 920000)));

                ClearingData(ref timeEllapsed);
                list.Add(timeEllapsed.Average());
            }
            AddString("Backpack", list.ToArray());

            void RandomFillingThings(Tuple<int, int>[] weightCost)
            {
                for (int i = 0; i < weightCost.Length; i++)
                    weightCost[i] = new Tuple<int, int>(rand.Next(60, 3000), rand.Next(500, 3000));
            }
        }
        public static void BinarySearch()
        {
            var list = new List<double>();
            double[] timeEllapsed;
            for (uint i = 2; i < 2002; i++)
            {
                var arr = new int[i];
                SortedFilling(arr);
                int key = arr[1];

                timeEllapsed = new double[9];
                for (int j = 0; j < timeEllapsed.Length; j++)
                    timeEllapsed[j] = Timering(() => BinarySearchTask.BinarySearch(arr.ToArray(), key));

                ClearingData(ref timeEllapsed);
                list.Add(timeEllapsed.Average());
            }
            AddString("BinarySearch", list.ToArray());

            void SortedFilling(int[] sortedArr)
            {
                sortedArr[0] = 0;
                for (int i = 1; i < sortedArr.Length; i++)
                    sortedArr[i] = rand.Next(sortedArr[i - 1], sortedArr[i - 1] + 20000);
            }
        }
        private static double Timering(Action act)
        {
            clock.Reset();
            clock.Start();
            act();
            clock.Stop();
            return clock.Elapsed.TotalMilliseconds;
        }
        private static void ClearingData(ref double[] timeArr)
        {
            if (timeArr.Length <= 3)
                return;

            const double deviasion = 1.8; //отклонение в X раз от среднего 2 мин. элементов
            Array.Sort(timeArr);
            var minAvg = (timeArr[0] + timeArr[1]) / 2;

            timeArr = timeArr.Where(e => e <= minAvg * deviasion).ToArray();
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
