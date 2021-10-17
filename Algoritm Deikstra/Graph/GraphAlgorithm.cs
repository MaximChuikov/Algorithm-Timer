using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphLibrary
{
    public class GraphAlgorithm
    {
        private readonly Random rand = new();
        public uint AlgorithmDeikstra(Vertex start, Vertex end)
        {
            var dict = new Dictionary<Vertex, uint>();
            dict.Add(start, 0);
            RecPoint(ref start);
            return dict[end];

            void RecPoint(ref Vertex i)
            {
                foreach (var e in i.neighbours)
                {
                    var n = e.GetNeighbour(i);
                    if (n.alive)
                        if (!dict.ContainsKey(n))
                            dict.Add(n, dict[i] + e.GetCost());
                        else if (dict[i] + e.GetCost() < dict[n])
                            dict[n] = dict[i] + e.GetCost();
                }
                var neigh = new List<Vertex>();
                foreach (var e in i.neighbours)
                    if (e.GetNeighbour(i).alive)
                        neigh.Add(e.GetNeighbour(i));
                i.alive = false;

                for (int j = 0; j < neigh.Count; j++)
                {
                    var f = neigh[j];
                    RecPoint(ref f);
                }
            }
        }
        public Graph CreateGraph(uint numOfVertex, uint numOfLayers, out Vertex start, out Vertex end)
        {
            var allEdge = new List<Edge>();

            var firstV = new Vertex((char)rand.Next(33, 91));
            numOfVertex--;

            start = firstV;
            Vertex myEnd = new Vertex((char)rand.Next(33, 91));
            RecAdd(new Vertex[] { start });
            end = myEnd;

            return new Graph(allEdge);

            void AddEdge(Vertex a, Vertex b)
            {
                var e = new Edge(a, b, (uint)rand.Next(1, 10));
                a.AddEdge(e);
                b.AddEdge(e);
                allEdge.Add(e);
            }
            void RecAdd(Vertex[] last)
            {
                if (numOfVertex == 0)
                {
                    myEnd = last[last.Length / 2];
                }
                else if (numOfVertex < numOfLayers)
                {
                    var list = new List<Vertex>();
                    for (int i = 0; i < numOfVertex; i++)
                    {
                        var v = new Vertex((char)rand.Next(33, 91));
                        list.Add(v);
                        foreach (var l in last)
                            AddEdge(l, v);
                    }
                    myEnd = list[list.Count / 2];
                }
                else if (numOfVertex >= numOfLayers)
                {
                    var arr = new Vertex[numOfLayers];
                    for (int i = 0; i < numOfLayers; i++)
                    {
                        arr[i] = new Vertex((char)rand.Next(33, 91));
                        foreach (var l in last)
                            AddEdge(l, arr[i]);
                    }
                    numOfVertex -= numOfLayers;
                    RecAdd(arr);
                }
            }
        }
    }
}
 