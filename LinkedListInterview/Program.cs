using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LinkedListInterview
{

    public class Node<T>
    {
        public Node(T value)
        {
            Value = value;
        }

        public T Value { get; private set; }

        public Node<T> NextNode { get; set; }
    }

    public class LinkedList<T> : IEnumerable<T>, ICollection<T>
    {
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

                int count = 0;
                Node<T> countNode = first;

                while (countNode != null)
                {
                    count++;
                    countNode = countNode.NextNode;
                }

                return count;
            }
        }

        public bool IsReadOnly
        {
            // this method is not readonly, i.e. you can add and remove items
            get { return false; }
        }

        // GetFirstNode and GetLastNode aren't necessary any more
        /*public Node<T> GetFirstNode()
        {
            return first;
        }

        public Node<T> GetLastNode()
        {
            return last;
        }*/

        public void Add(T Value)
        {
            Node<T> node = new Node<T>(Value);

            if (first == null)
            {
                first = node;
                last = node;
            }
            else
            {
                //first.NextNode = node;
                //first = node;
                last.NextNode = node;
                last = node;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            // take this "enumerator" out...
            /*var node = GetFirstNode();
            while (node != null)
            {
                yield return node.Value;
                node = node.NextNode;
            }*/

            // ...and use the implementation of the LinkedListEnumerator
            // NOTE! the constructor may not be correct/require more parameters
            return new LinkedListEnumerator<T>(first);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Clear()
        {
            first = null;
            last = null;
        }

        public bool Contains(T item)
        {
            if (first == null)
            {
                return false;
            }
            else
            {
                Node<T> searchNode = first;

                while (searchNode != null)
                {
                    if (searchNode.Value.ToString() == item.ToString())
                    {
                        return true;
                    }

                    searchNode = searchNode.NextNode;
                }

                return false;
            }
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            Node<T> node = first;

            int index = arrayIndex;

            while (node != null)
            {
                array[index++] = node.Value;
                node = node.NextNode;
            }
        }

        public bool Remove(T item)
        {
            if (first == null)
            {
                return false;
            }

            if (!Contains(item) == false)
            {
                return false;
            }

            Node<T> previousNode = null;
            Node<T> removeNode = first;

            while (removeNode != null)
            {
                if (removeNode.Value.ToString() == item.ToString())
                {
                    if (removeNode == first)
                    {
                        first = removeNode.NextNode;
                        return true;
                    }
                    else if (removeNode == last)
                    {
                        previousNode.NextNode = null;
                        return true;
                    }
                    previousNode.NextNode = removeNode.NextNode;
                    return true;
                }

                previousNode = removeNode;
                removeNode = removeNode.NextNode;
            }

            return false;
        }
    }

    public class LinkedListEnumerator<T> : IEnumerator<T>
    {
        Node<T> FirstNode;
        Node<T> node;
        // implement this for the linked list...
        public LinkedListEnumerator(Node<T> node)
        {
            this.node = node;
            FirstNode = node;
        }
        public T Current
        {
            get
            {
                return node.Value;
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return node;
            }
        }

        public void Dispose()
        {
            node = null;
        }

        public bool MoveNext()
        {
            if (node.NextNode != null)
            {
                node = node.NextNode;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Reset()
        {
            node = FirstNode;
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            //LinkedList<string> linkedList = new LinkedList<string>();
            //linkedList.Add("Mon");
            //linkedList.Add("Tue");
            //linkedList.Add("Wed");

            //foreach(string item in linkedList)
            //{
            //    Console.WriteLine(item);
            //}

            //Console.WriteLine("Number of Items: " + linkedList.Count);
            //Console.WriteLine("Does LinkedList Contain Mon?");
            //Console.WriteLine(linkedList.Contains("Mon"));

            //Console.WriteLine("Remove Wed");
            //linkedList.Remove("Wed");

            //foreach (var item in linkedList)
            //{
            //    Console.WriteLine(item);
            //}

            //Console.WriteLine("Copy To Array");
            //string[] daysOfTheWeek = new string[7];
            //linkedList.CopyTo(daysOfTheWeek, 3);

            //foreach (string day in daysOfTheWeek)
            //{
            //    Console.WriteLine(day);             
            //}

            //Console.WriteLine("Before Clear");
            //linkedList.Clear();
            //Console.WriteLine("After Clear Count: " + linkedList.Count());


            LinkedList<string> DaysOfTheWeek = new LinkedList<string>();
            DaysOfTheWeek.Add("Monday");
            DaysOfTheWeek.Add("Tuesday");
            DaysOfTheWeek.Add("Wensday");
            DaysOfTheWeek.Add("Thursday");
            DaysOfTheWeek.Add("Friday");
            DaysOfTheWeek.Add("Saturday");
            DaysOfTheWeek.Add("Sunday");

            var Result = DaysOfTheWeek.Where(d => d.StartsWith("M"));

            //Console.WriteLine(DaysOfTheWeek.Count.ToString());
            foreach(var Item in DaysOfTheWeek)
            {
                Console.WriteLine(Item);
            }

            Console.ReadKey();
        }
    }
}
