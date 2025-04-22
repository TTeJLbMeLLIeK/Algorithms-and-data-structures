using System;
using System.Collections.Generic;

class Graph
{
    private Dictionary<string, List<string>> adjacencyList;

    public Graph()
    {
        adjacencyList = new Dictionary<string, List<string>>();
    }

    public void AddVertex(string vertex)
    {
        if (!adjacencyList.ContainsKey(vertex))
        {
            adjacencyList[vertex] = new List<string>();
        }
    }

    public void AddEdge(string vertex1, string vertex2)
    {
        AddVertex(vertex1);
        AddVertex(vertex2);

        if (!adjacencyList[vertex1].Contains(vertex2))
        {
            adjacencyList[vertex1].Add(vertex2);
        }

        if (!adjacencyList[vertex2].Contains(vertex1))
        {
            adjacencyList[vertex2].Add(vertex1);
        }
    }

    public void PrintGraph()
    {
        foreach (var vertex in adjacencyList)
        {
            Console.Write(vertex.Key + " -> ");
            Console.WriteLine(string.Join(", ", vertex.Value));
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Graph graph = new Graph();

        graph.AddEdge("A", "B");
        graph.AddEdge("A", "C");
        graph.AddEdge("B", "D");
        graph.AddEdge("C", "D");
        graph.AddEdge("E", "F");

        graph.PrintGraph();
    }
}