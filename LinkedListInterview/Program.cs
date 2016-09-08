using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListInterview
{

    public class Node<T>
    {

        //public Node<T> LastNode { get; set}
        public T Value { get; private set; }

        public Node<T> NextNode { get; set; }


        public Node(T value)
        {
            Value = value;
        }
    }

    public class LinkedList<T> : IEnumerable<T>, ICollection<T>
    {
        private Node<T> node;
        private Node<T> first;

        public int Count
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool IsReadOnly
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Node<T> GetFirstNode()
        {
            return first;
        }
        
        public void Add(T Value)
        {
            Node<T> node = new Node<T>(Value);
            if (this.node==null)
            {
                this.node = node;
                this.first = node;
            }
            else
            {
                this.node.NextNode = node;
                this.node = node;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            var node = GetFirstNode();

            while (node != null)
            {
                yield return node.Value;

                node = node.NextNode;
            }
            
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            LinkedList<String> LL = new LinkedList<string>();
            LL.Add("Mon");
            LL.Add("Tue");
            LL.Add("Wen");

            foreach(var Item in LL)
            {
                Console.WriteLine(Item);
            }
            Console.ReadKey();
        }

        //Try doublely linked list
        //
        //Implement ienumerator of T
        //implement icoolection
    }

    
}
