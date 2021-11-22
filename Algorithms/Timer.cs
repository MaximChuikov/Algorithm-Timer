using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using GraphLibrary;
using Query;

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
        public static void HanobinsTowers()
        {
            var list = new List<double>();
            double[] timeEllapsed;
            for (int i = 1; i <= 25; i++)
            {
                timeEllapsed = new double[5];
                for (int j = 0; j < timeEllapsed.Length; j++)
                    timeEllapsed[j] = Timering(() => HanobinsTowersTask.HanobinsTowers(i));
                ClearingData(ref timeEllapsed);
                list.Add(timeEllapsed.Average());
            }
            AddString("Hanobins Towers", list.ToArray());
        }
        public static void QueueEnqueChallenge()
        {
            var myRecords = new List<double>();
            var systemRecords = new List<double>();

            MyQueue<int> myQueue = new();
            Queue<int> systemQueue = new();

            Action<int, Action> cycle = (int times, Action act) =>
            {
                for (int i = 0; i < times; i++)
                    act();
            };

            for (int i = 1; i <= 5000; i++)
            {
                myQueue.Clear();
                systemQueue.Clear();

                Action act = () => myQueue.Enqueue(rand.Next());
                myRecords.Add(Timering(() => cycle(i * 10, () => myQueue.Enqueue(rand.Next())))); 
                systemRecords.Add(Timering(() => cycle(i * 10, () => systemQueue.Enqueue(rand.Next()))));
            }
            AddString("My Queue enque", myRecords.ToArray());
            AddString("System Queue enque", systemRecords.ToArray());
        }
        public static void QueueRandomChallenge()
        {
            var myRecords = new List<double>();
            var systemRecords = new List<double>();

            MyQueue<int> myQueue = new();
            Queue<int> systemQueue = new();

            Action[] myMethods = new Action[]
            {
                () => myQueue.Enqueue(rand.Next()),
                () =>
                {
                    try { myQueue.Dequeue(); }
                    catch {};
                },
                () => myQueue.TryPeek(out int value),
                () => { var a = myQueue.IsEmpty; }
            };

            Action[] systemMethods = new Action[]
            {
                () => systemQueue.Enqueue(rand.Next()),
                () =>
                {
                    try { systemQueue.Dequeue(); }
                    catch {};
                },
                () => systemQueue.TryPeek(out int value),
                () => { var a = systemQueue.Count == 0; }
            };

            Action<int[], Action[]> cycle = (int[] commands, Action[] acts) =>
            {
                foreach (var i in commands)
                    acts[i]();
            };

            for (int i = 1; i <= 350; i++)
            {
                myQueue.Clear();
                systemQueue.Clear();

                var commands = GenerateArray(i * 2, 4);

                myRecords.Add(Timering(() => cycle(commands, myMethods)));
                systemRecords.Add(Timering(() => cycle(commands, systemMethods)));
            }
            AddString("My Queue random commands", myRecords.ToArray());
            AddString("System Queue random commands", systemRecords.ToArray());

            int[] GenerateArray(int lenght, int max)
            {
                var arr = new int[lenght];
                for (int i = 0; i < arr.Length; i++)
                    arr[i] = rand.Next(0, max);
                return arr;
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
