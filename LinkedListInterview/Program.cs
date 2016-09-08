﻿using System;
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
            get
            {
                throw new NotImplementedException();
            }
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
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            if(first == null)
            {
                return false;
            }
            else if(Contains(item) == false)
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
            LinkedList<String> LL = new LinkedList<string>();
            LL.Add("Mon");
            LL.Add("Tue");
            LL.Add("Wen");

            foreach(var Item in LL)
            {
                Console.WriteLine(Item);
            }
            Console.WriteLine("Number of Items: " + LL.Count());
            Console.WriteLine("Does LinkedList Contain Mon?");
            Console.WriteLine(LL.Contains("Mon"));
            Console.WriteLine("Remove Wen");
            LL.Remove("Wen");
            foreach (var Item in LL)
            {
                Console.WriteLine(Item);
            }
            Console.WriteLine("Before Clear");
            LL.Clear();
            Console.WriteLine("After Clear Count: " + LL.Count());
            Console.ReadKey();
        }

        //Try doublely linked list
        //
        //Implement ienumerator of T
        //implement icoolection
    }

    
}
