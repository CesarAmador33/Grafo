using System;
using System.Collections.Generic;

public class Graph
{
    private int vertices; // Número de vértices
    private List<int>[] adjacencyList; // Lista de adyacencia

    // Constructor
    public Graph(int v)
    {
        vertices = v;
        adjacencyList = new List<int>[v];
        for (int i = 0; i < v; i++)
        {
            adjacencyList[i] = new List<int>();
        }
    }

    // Método para agregar una arista
    public void AddEdge(int source, int destination)
    {
        adjacencyList[source].Add(destination); // Agregar arista de source a destination
        adjacencyList[destination].Add(source); // Para grafos no dirigidos, agrega en ambas direcciones
    }

    // Método para realizar DFS
    public void DFS(int start)
    {
        bool[] visited = new bool[vertices]; // Marca los nodos visitados
        Console.WriteLine("DFS a partir del vértice " + start + ":");
        DFSUtil(start, visited);
    }

    // Método auxiliar para DFS
    private void DFSUtil(int vertex, bool[] visited)
    {
        // Marca el nodo actual como visitado y lo imprime
        visited[vertex] = true;
        Console.Write(vertex + " ");

        // Recurre para todos los vértices adyacentes al vértice actual
        foreach (var neighbor in adjacencyList[vertex])
        {
            if (!visited[neighbor])
            {
                DFSUtil(neighbor, visited);
            }
        }
    }
}
class Program
{
    static void Main(string[] args)
    {
        Graph graph = new Graph(5); // Crea un grafo con 5 vértices

        // Agrega aristas
        graph.AddEdge(0, 1);
        graph.AddEdge(0, 4);
        graph.AddEdge(1, 2);
        graph.AddEdge(1, 3);
        graph.AddEdge(1, 4);
        graph.AddEdge(2, 3);
        graph.AddEdge(3, 4);

        // Ejecuta DFS comenzando desde el vértice 0
        graph.DFS(0);
    }
}
