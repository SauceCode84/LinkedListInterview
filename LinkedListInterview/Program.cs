using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListInterview
{
    public class LinkedList<T>
    {
        // your code goes here
        // tesing 123
       
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Node<string> testNode = new Node<string>("Mon");
        }
    }

    public class Node<T>
    {
        public T Value { get; private set; }

        public Node<T> NextNode { get; set; }

        public Node(T value)
        {
            Value = value;
        }
    }
}
