using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphLibrary
{
    public class Graph
    {
        public List<Edge> edges;
        public List<Vertex> vertices;
        public Graph(List<Edge> graphNodes)
        {
            edges = graphNodes;

            vertices = new List<Vertex>();
            foreach (var e in edges)
            {
                var t = e.GetVertex();
                if (!vertices.Contains(t.Item1))
                    vertices.Add(t.Item1);
                if (!vertices.Contains(t.Item2))
                    vertices.Add(t.Item2);
            }
        }
        public void DeleteEdge(Edge del)
        {
            foreach(var v in edges)
                if(v == del)
                {
                    edges.Remove(v);
                    break;
                }
        }
    }
    public class Vertex
    {
        public bool alive = true;
        public char name;

        public List<Edge> neighbours;
        public Vertex(char n) 
        {
            neighbours = new List<Edge>();

            Random rand = new();
            name = n;
        }
        public void AddEdge(Edge e)
        {
            neighbours.Add(e);
        }

        public override string ToString()
        {
            return name.ToString();
        }
    }
    public class Edge
    {
        Vertex one, two;
        uint cost;
        public Edge(Vertex one, Vertex two, uint cost)
        {
            this.one = one;
            this.two = two;
            this.cost = cost;
        }
        public Tuple<Vertex, Vertex> GetVertex() => new Tuple<Vertex, Vertex>(one, two); 
        public Vertex? GetNeighbour(Vertex v)
        {
            if (v == one)
                return two;
            else if (v == two)
                return one;
            else
                return null;
        }
        public uint GetCost() => cost;
        public override string ToString()
        {
            return one.ToString() + two.ToString() + " " + cost;
        }
    }
}
