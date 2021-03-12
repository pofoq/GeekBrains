using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_06
{
    public class GrafTree
    {
        public Node Root { get { return root; } }
        List<Node> nodes = new List<Node>();
        public void Add(Node node) => nodes.Add(node);
        Node root
        {
            get
            {
                if (nodes is null || nodes.Count == 0)
                    return null;
                return nodes[0];
            }
        }

        public GrafTree()
        {
            nodes = new List<Node>();
        }

        public Node BFS(int value)
        {
            List<Node> done = new List<Node>(); 
            Queue<Node> q = new Queue<Node>();
            q.Enqueue(root);
            while (q.Count != 0)
            {
                var el = q.Dequeue();
                Console.WriteLine(el.Value);
                if (el.Value == value)
                    return el;
                done.Add(el);
                foreach(var e in el.Edges)
                {
                    if (!done.Contains(e.Node))
                        q.Enqueue(e.Node);
                }
            }
            return null;
        }

        public Node DFS(int value)
        {
            List<Node> done = new List<Node>();
            var stack = new Stack<Node>();
            stack.Push(root);
            while (stack.Count != 0)
            {
                var el = stack.Pop();
                Console.WriteLine(el.Value);
                if (el.Value == value)
                    return el;
                done.Add(el);
                foreach (var e in el.Edges)
                {
                    if (!done.Contains(e.Node))
                        stack.Push(e.Node);
                }
            }
            return null;
        }

        public static GrafTree GetDefault()
        {
//         1---2---3---4
//         |       |
//         5---6---7
            GrafTree graf = new GrafTree();
            Node node1 = new Node { Value = 1 };
            Node node2 = new Node { Value = 2 };
            Node node3 = new Node { Value = 3 };
            Node node4 = new Node { Value = 4 };
            Node node5 = new Node { Value = 5 };
            Node node6 = new Node { Value = 6 };
            Node node7 = new Node { Value = 7 };

            node1.Edges = new List<Edge>
            {
                new Edge { Weight = 12, Node = node2 },
                new Edge { Weight = 15, Node = node5 }
            };
            node2.Edges = new List<Edge>
            {
                new Edge { Weight = 21, Node = node1 },
                new Edge { Weight = 23, Node = node2 }
            };
            node3.Edges = new List<Edge>
            {
                new Edge { Weight = 32, Node = node2 },
                new Edge { Weight = 34, Node = node4 },
                new Edge { Weight = 37, Node = node7 }
            };
            node4.Edges = new List<Edge>
            {
                new Edge { Weight = 43, Node = node3 }
            };
            node5.Edges = new List<Edge>
            {
                new Edge { Weight = 51, Node = node1 },
                new Edge { Weight = 56, Node = node6 }
            };
            node6.Edges = new List<Edge>
            {
                new Edge { Weight = 65, Node = node5 },
                new Edge { Weight = 67, Node = node7 }
            };
            node7.Edges = new List<Edge>
            {
                new Edge { Weight = 76, Node = node6 },
                new Edge { Weight = 73, Node = node3 }
            };

            graf.nodes = new List<Node> { node1,node2,node3,node4,node5,node6,node7 };

            return graf;
        }
    }

    public class Node //Вершина
    {
        public int Value { get; set; }
        public List<Edge> Edges { get; set; } //исходящие связи

        public override bool Equals(object obj)
        {
            Node node = obj as Node;
            if (node is null)
                return false;
            return node.Value == Value;
        }
    }

    public class Edge //Ребро
    {
        public int Weight { get; set; } //вес связи
        public Node Node { get; set; } // узел, на который связь ссылается
    }
}
