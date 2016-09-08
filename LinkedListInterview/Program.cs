using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListInterview
{

    public class Node<T>
    {
        public T Value { get; private set; }

        public Node<T> NextNode { get; set; }

        public Node(T value)
        {
            Value = value;
        }
    }

    public class LinkedList<T>
    {

        private Node<T> node;
       
    }

    public class Program
    {
        public static void Main(string[] args)
        {
        }
    }

    
}
