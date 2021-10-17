using System;
using System.Collections.Generic;
using GraphLibrary;
namespace Algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            var g = new GraphAlgorithm();
            Vertex a, b;
            var gra = g.CreateGraph(4, 1, out a, out b);
            var h = g.AlgorithmDeikstra(a, b);
            Console.WriteLine(h);
            Console.ReadKey();
        }
    }
}
