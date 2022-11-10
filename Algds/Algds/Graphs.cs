using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algds
{
    public static class Graphs
    {

        public static int dijkstra(int[,] graph, int source, int dest) 
        {
            int[] distances = new int[graph.GetLength(0)];
            for (int i = 0; i < distances.Length; i++)
            {
                distances[i] = Int32.MaxValue;
            }

            distances[source] = 0;
            bool[] visited = new bool[graph.GetLength(0)];
            int currentNode = source;

            while (!visited.All(x => x) && distances[currentNode] != Int32.MaxValue)
            {
                List<int> neighbors = GetUnvisitedNeighbors(graph, visited, currentNode);
                foreach (int neighbor in neighbors)
                {
                    int newDistance = distances[currentNode] + graph[currentNode, neighbor];
                    if (newDistance < distances[neighbor]) { distances[neighbor] = newDistance; }
                }
                visited[currentNode] = true;
                currentNode = distances
                    .Where((d, i) => !visited[i]) //Nodes that have not been visited
                    .OrderBy(d => d)              //Order so first is minimum
                    .Select((d, i) => i)          //Select index
                    .FirstOrDefault();            //Get first (which is minimum) or default value of int (0)
            }
            return distances[dest];
        }

        public static List<int> GetUnvisitedNeighbors(int[,] graph, bool[] visited, int node)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < graph.GetLength(1); i++)
            {
                if (graph[node, i] < Int32.MaxValue && node != i && !visited[i])
                {
                    result.Add(i);
                }
            }
            return result;
        }
    }
}
