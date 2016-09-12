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

    public class Laptop
    {
        private string type;
        private string processor;
        private string ram;
        private string screenSize;

        public string Type
        {
            get
            {
                return type;
            }

            set
            {
                type = value;
            }
        }

        public string Processor
        {
            get
            {
                return processor;
            }

            set
            {
                processor = value;
            }
        }

        public string Ram
        {
            get
            {
                return ram;
            }

            set
            {
                ram = value;
            }
        }

        public string ScreenSize
        {
            get
            {
                return screenSize;
            }

            set
            {
                screenSize = value;
            }
        }

        public Laptop(string type, string processor, string ram, string screenSize)
        {
            this.Type = type;
            this.Processor = processor;
            this.Ram = ram;
            this.ScreenSize = screenSize;
        } 
    }
    public class Laptops : IEnumerator, IEnumerable
    {
        private Laptop[] LaptopList;
        private int Count;
        public Laptops()
        {
            Count = -1;
            LaptopList = new Laptop[3]
            {
                new Laptop("Gigabyte","Quad Core 3.4GHz","16 GB DDR3 1333MHz","17 inch"),
                new Laptop("Asus","Dual Core 2.2GHz","4 GB DDR3 800MHz","15 inch"),
                new Laptop("Dell","Single Core 3.4GHz","2 GB DDR2 800MHz","18 inch")
            };
        }
        public object Current
        {
            get
            {
                return LaptopList[Count];
            }
        }

        public IEnumerator GetEnumerator()
        {
            return this;
        }

        public bool MoveNext()
        {
            Count++;
            return (Count < LaptopList.Length);
        }

        public void Reset()
        {
            Count = 0;
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
            LL.Clear();
            Console.WriteLine("After Clear Count: " + LL.Count());
            Console.WriteLine("Press Any Key to Test Laptop Class.........");
            Console.ReadKey();
            Console.WriteLine("Laptops");
            Laptops LPS = new Laptops();
            foreach(Laptop LP in LPS)
            {
               Console.WriteLine("Type: " + LP.Type + "\n" + "Screen Size: " + LP.ScreenSize + "\n" + "RAM: " + LP.Ram + "\n" + "Processor: " + LP.Processor);
               Console.WriteLine("");
            }
            Console.ReadKey();
        }
    }
}
