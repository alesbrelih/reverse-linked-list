using System;

namespace ReverseLinked
{
    class Program
    {
        class LinkedList
        {
            public Node Root { get; set; }
            public void Insert(int value)
            {
                this.Root = LinkedList.InsertRecursive(value, this.Root);
            }
            public void Reverse(bool recursive = true)
            {
                if (recursive)
                {
                    //recursive
                    ReverseRecursive(this.Root, null);
                } else
                {
                    // iterative
                    ReverseIterative();
                }
            }
            public static Node InsertRecursive(int value, Node root)
            {
                if (root == null)
                {
                    return new Node(value);
                }
                root.Next = InsertRecursive(value, root.Next);
                return root;
            }

            public void ReverseRecursive(Node node, Node previous)
            {
                if (node == null)
                {
                    this.Root = previous;
                    return;
                }

                Node pivot = node.Next;
                node.Next = previous;
                ReverseRecursive(pivot, node);
            }
            public void ReverseIterative()
            {
                Node node = this.Root;
                Node previous = null;
                Node pivot = null;
                while (node != null)
                {
                    pivot = node.Next;
                    node.Next = previous;
                    previous = node;
                    node = pivot;
                }
                this.Root = previous;
            }
        }
        class Node
        {
            public Node Next { get; set; }
            public int Value { get; set; }

            public Node(int value)
            {
                this.Value = value;
            }
        }
        static void Main(string[] args)
        {
            LinkedList root = new LinkedList();
            root.Insert(1);
            root.Insert(2);
            root.Insert(3);
            root.Insert(4);
            root.Insert(5);
            root.Insert(6);

            Node first = root.Root;
            while ( first != null)
            {
                Console.WriteLine(first.Value);
                first = first.Next;
            }

            root.Reverse(false);
            first = root.Root;
            while (first != null)
            {
                Console.WriteLine(first.Value);
                first = first.Next;
            }
            root.Reverse();
            first = root.Root;
            while (first != null)
            {
                Console.WriteLine(first.Value);
                first = first.Next;
            }
            Console.ReadLine();
        }
    }
}
