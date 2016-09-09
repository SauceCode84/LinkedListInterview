using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

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

    public class LinkedList<T> :
        IEnumerable<T>,
        ICollection<T>
    {
        private Node<T> node;
        private Node<T> first;
        private Node<T> last;

        public int Count
        {         
            get
            {

                if (first == null)
                {
                    return 0;
                }
                else
                {
                    int itemcount = 0;
                    Node<T> countnode = first;
                    while (countnode != null)
                    {
                        itemcount++;
                        countnode = countnode.NextNode;
                    }
                    return itemcount;
                }
            }
        }

        public bool IsReadOnly
        {
            // this method is not readonly, i.e. you can add and remove items
            get { return false; }
        }

        public Node<T> GetFirstNode()
        {
            return first;
        }
        public Node<T> GetLastNode()
        {
            return last;
        }
        
        public void Add(T Value)
        {
            Node<T> node = new Node<T>(Value);
            if (this.node==null)
            {
                this.node = node;
                this.first = node;
                this.last = node;
            }
            else
            {
                this.node.NextNode = node;
                this.node = node;
                this.last = node;
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
            first = null;
            node = null;
        }

        public bool Contains(T item)
        {
            if(first == null)
            {
                return false;
            }
            else
            {
                Node<T> containsnode = first;
                while (containsnode != null)
                {
                    if(containsnode.Value.ToString() == item.ToString())
                    {
                        return true;
                    }
                    containsnode = containsnode.NextNode;
                }
                return false;
            }
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            Node<T> node = first;
            int indexcount = arrayIndex;
            while (node != null)
            {
                array[indexcount] = node.Value;
                indexcount++;       
                node = node.NextNode;
            }
        }

        public bool Remove(T item)
        {
            if (first == null)
            {
                return false;
            }
            else if (Contains(item) == false)
            {
                return false;
            }
            else
            {
                Node<T> previousnode = null;
                Node<T> removenode = first;
                while (removenode != null)
                {
                    if (removenode.Value.ToString() == item.ToString())
                    {
                        if (removenode == first)
                        {
                            first = removenode.NextNode;
                            return true;
                        }
                        else if (removenode == last)
                        {
                            previousnode.NextNode = null;
                            return true;
                        }
                        previousnode.NextNode = removenode.NextNode;
                        return true;
                    }
                    previousnode = removenode;
                    removenode = removenode.NextNode;
                }
                return false;
            }
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            LinkedList<string> linkedList = new LinkedList<string>();
            linkedList.Add("Mon");
            linkedList.Add("Tue");
            linkedList.Add("Wed");

            foreach(string item in linkedList)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Number of Items: " + linkedList.Count);
            Console.WriteLine("Does LinkedList Contain Mon?");
            Console.WriteLine(linkedList.Contains("Mon"));

            Console.WriteLine("Remove Wed");
            linkedList.Remove("Wed");

            foreach (var item in linkedList)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Copy To Array");
            string[] daysOfTheWeek = new string[7];
            linkedList.CopyTo(daysOfTheWeek, 3);

            foreach (string day in daysOfTheWeek)
            {
                Console.WriteLine(day);             
            }

            Console.WriteLine("Before Clear");

            linkedList.Clear();

            Console.WriteLine("After Clear Count: " + linkedList.Count);

            Console.ReadKey();
        }

        //Try doublely linked list
        //
        //Implement ienumerator of T
        //implement icoolection
    }
}
