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

    public void AddEdge(string from, string to)
    {
        AddVertex(from);
        AddVertex(to);

        if (!adjacencyList[from].Contains(to))
        {
            adjacencyList[from].Add(to);
        }
    }

    public void PrintGraph()
    {
        foreach (var vertex in adjacencyList)
        {
            Console.Write(vertex.Key + " -> ");
            if (vertex.Value.Count == 0)
            {
                Console.WriteLine("Пусто");
            }
            else
            {
                Console.WriteLine(string.Join(", ", vertex.Value));
            }
        }
    }

    public List<string> TopologicalSort()
    {
        var visited = new HashSet<string>();
        var result = new Stack<string>();
        var tempMarks = new HashSet<string>();

        foreach (var vertex in adjacencyList.Keys)
        {
            if (!visited.Contains(vertex))
            {
                if (!TopologicalSortUtil(vertex, visited, result, tempMarks))
                {
                    Console.WriteLine("Граф содержит цикл. Топологическая сортировка невозможна.");
                    return new List<string>();
                }
            }
        }

        return new List<string>(result);
    }

    private bool TopologicalSortUtil(string vertex, HashSet<string> visited, Stack<string> result, HashSet<string> tempMarks)
    {
        if (tempMarks.Contains(vertex))
        {
            return false;
        }

        if (!visited.Contains(vertex))
        {
            tempMarks.Add(vertex);

            foreach (var neighbor in adjacencyList[vertex])
            {
                if (!TopologicalSortUtil(neighbor, visited, result, tempMarks))
                {
                    return false;
                }
            }

            tempMarks.Remove(vertex);
            visited.Add(vertex);
            result.Push(vertex);
        }

        return true;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Graph graph = new Graph();

        graph.AddEdge("A", "C");
        graph.AddEdge("B", "C");
        graph.AddEdge("C", "D");
        graph.AddEdge("D", "E");
        graph.AddEdge("F", "B");

        Console.WriteLine("Граф:");
        graph.PrintGraph();

        Console.WriteLine("\nТопологическая сортировка:");
        var sorted = graph.TopologicalSort();
        Console.WriteLine(string.Join(" -> ", sorted));
    }
}