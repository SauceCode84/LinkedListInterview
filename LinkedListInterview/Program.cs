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
        private T value;
        private Node<T> nextNode;

        public T Value
        {
            get
            {
                return value;
            }

            private set
            {
                this.value = value;
            }
        }

        public Node<T> NextNode
        {
            get
            {
                return nextNode;
            }

            set
            {
                nextNode = value;
            }
        }

        public Node(T value)
        {
            Value = value;
        }
    }
}
