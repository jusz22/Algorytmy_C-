using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Security.Cryptography.X509Certificates;
using System.Net.Http.Headers;

namespace c_s_dijkstra
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Przyk1();
        }

        private void Przyk1()
        {
            Node n0 = new Node(0);
            Node n1 = new Node(1);
            Node n2 = new Node(2);
            Node n3 = new Node(3);
            Node n4 = new Node(4);
            Node n5 = new Node(5);
            Node n6 = new Node(6);
            Node n7 = new Node(7);

            Graph graph = new Graph(new Edge(5, n0, n1));
            graph.AddEdge(new Edge(9, n1, n2));
            graph.AddEdge(new Edge(3, n2, n7));
            graph.AddEdge(new Edge(3, n6, n7));
            graph.AddEdge(new Edge(6, n5, n6));
            graph.AddEdge(new Edge(6, n5, n1));
            graph.AddEdge(new Edge(7, n1, n7));
            graph.AddEdge(new Edge(3, n0, n6));
            graph.AddEdge(new Edge(9, n3, n2));
            graph.AddEdge(new Edge(4, n4, n2));
            graph.AddEdge(new Edge(5, n2, n6));
            graph.AddEdge(new Edge(2, n5, n4));
            graph.AddEdge(new Edge(6, n5, n1));
            graph.AddEdge(new Edge(3, n3, n6));
            graph.AddEdge(new Edge(8, n1, n4));
            graph.AddEdge(new Edge(1, n4, n6));
            graph.AddEdge(new Edge(5, n0, n3));

            Graph kruskal = graph.KruskalAlg();

            kruskal.ShowGraph();
        }

        private void Przyk2()
        {
            Node n0 = new Node(0);
            Node n1 = new Node(1);
            Node n2 = new Node(2);
            Node n3 = new Node(3);

            Graph graph = new Graph(new Edge(10, n0, n1));

            graph.AddEdge(new Edge(6, n0, n2));
            graph.AddEdge(new Edge(5, n0, n3));
            graph.AddEdge(new Edge(15, n1, n3));
            graph.AddEdge(new Edge(4, n2, n3));

            graph.ShowGraph();

            Graph krusnal = graph.KruskalAlg();

            krusnal.ShowGraph();
        }
        private void NWP()
        {
            int[, ] matrix = new int[9,5];
            for(int i = 0; i < 9; i++)
            {
                matrix[i, 0] = 0;
            }
            for(int i = 0; i < 5; i++)
            {
                matrix[0, i] = 0;
            }
            for(int i = 1; i < 9; i++)
            {
                for(int j = 1; j < 5; j++)
                {

                }
            }
        }
    }

    public class Graph
    {
        public List<Node> nodes = new List<Node>();
        public List<Edge> edges = new List<Edge>();

        public Graph(Edge edge)
        {
            edges.Add(edge);
            nodes.Add(edge.start);
            nodes.Add(edge.end);
        }

        public void AddEdge(Edge edge)
        {
            edges.Add(edge);

            if (!nodes.Contains(edge.start))
                nodes.Add(edge.start);

            if (!nodes.Contains(edge.end))
                nodes.Add(edge.end);
        }

        private int NewNodesCountOnAdd(Edge edge)
        {
            int foundCase = 0;

            if (!nodes.Contains(edge.start))
                foundCase++;

            if (!nodes.Contains(edge.end))
                foundCase++;

            return foundCase;
        }

        public Graph KruskalAlg()
        {
            List<Graph> subGraphs = new List<Graph>();

            var edges = this.edges.OrderBy(e => e.weight);
            foreach (var edge in edges)
            {
                if (subGraphs.Count == 0)
                {
                    subGraphs.Add(new Graph(edge));
                    continue;
                }

                Graph nodeAddedGraph = null;
                for (int i = 0; i < subGraphs.Count; i++)
                {
                    Graph graph = subGraphs[i];

                    int newNodesCountOnAdd = graph.NewNodesCountOnAdd(edge);
                    if (newNodesCountOnAdd == 0)
                    {

                    }
                    else if (newNodesCountOnAdd == 1)
                    {
                        if (nodeAddedGraph == null)
                        {
                            nodeAddedGraph = graph;
                            graph.AddEdge(edge);
                        }
                        else
                        {
                            nodeAddedGraph.Join(graph);
                            subGraphs.RemoveAt(i);
                            break;
                        }
                    }
                    else
                    {
                        subGraphs.Add(new Graph(edge));
                    }
                }
            }

            return subGraphs[0];
        }
        public float[] Dijkstra(Graph graph, Node currentNode)
        {
            int numOfNodes = graph.nodes.Count;
            bool[] visited = new bool[numOfNodes];
            float[] weights = new float[numOfNodes];
            

            for (int i = 0; i < numOfNodes; i++)
            {
                weights[i] = int.MaxValue;
                visited[i] = false;
            }

            weights[currentNode.value] = 0f;

            for (int i = 0; i < numOfNodes - 1; i++)
            {
                int u = FindMinIndex(weights, visited);
                visited[u] = true;

                foreach (var edge in )
                {

                }

            }


        }

        int FindMinIndex(float[] weights, bool[] visited)
        {
            float minValue = float.MaxValue;
            int minIndex = -1;
            for (int i = 0; i < weights.Count(); i++)
            {
                if (visited[i] == false && weights[i] <= minValue)
                    minValue = weights[i];
                minIndex = i;
            }
            return minIndex;
        }

        public void Join(Graph graph)
        {
            foreach (Edge edge in graph.edges)
                AddEdge(edge);
        }

        public void ShowGraph()
        {
            foreach (var edge in edges)
                MessageBox.Show($"{edge.start.value} -- {edge.end.value} == {edge.weight}");
        }
        public Node FindNodeFromValue(int value, Graph graph)
        {
            foreach (var item in graph.nodes)
            {
                if (item.value == value)
                {
                    return item;
                }
                return null;
            }
            return null;
        }
    }

    public class Edge
    {
        public float weight;
        public Node start;
        public Node end;

        public Edge(float weight, Node start, Node end)
        {
            this.weight = weight;
            this.start = start;
            this.end = end;
        }
    }

    public class Node
    {
        public int value;
        public List<Edge> edges;

        public Node(int value)
        {
            this.value = value;
            this.edges = new List<Edge>();
        }
    }
}