using System;
using System.Collections;
using System.Collections.Generic;

namespace WindowsFormsApp1
{
    internal class LinkedList<T> : IEnumerable<T>
    {
        private LinkedListNode<T> Dummy;
        public LinkedListNode<T> First => this.Dummy.Next;
        public LinkedListNode<T> Last => this.Dummy.Previous;
        public int Length { get; private set; }
        public int totalIndex = 0;

        public LinkedList()
        {
            this.Dummy = new LinkedListNode<T>();
            this.Dummy.Next = this.Dummy;
            this.Dummy.Previous = this.Dummy;
        }

        public LinkedListNode<T> Find(T x)
        {
            var node = this.First;
            while (node != null && !EqualityComparer<T>.Default.Equals(node.Value, x))
            {
                node = node.Next;
            }
            return node;
        }

        public LinkedListNode<T> FindIndex(int x)
        {
            var node = this.First;
            if (First.Index <= x && Last.Index >= x)
            {
                while (node != null && node.Index != x)
                {
                    node = node.Next;
                }
                return node;
            }
            else
            {
                Console.WriteLine(x.ToString() + " is not proper num.\nFirst.Index is " + First.Index.ToString() + " Last.Index is " + Last.Index.ToString());
                return null;
            };
        }

        public void InsertAfter(LinkedListNode<T> node, T value)
        {
            var newNode = new LinkedListNode<T>();
            newNode.Value = value;
            newNode.Index = totalIndex;
            newNode.Next = node.Next;
            newNode.Previous = node;

            node.Next.Previous = newNode;
            node.Next = newNode;

            this.Length += 1;
            totalIndex++;
        }

        public void InsertBefore(LinkedListNode<T> node, T value)
        {
            var newNode = new LinkedListNode<T>();
            newNode.Value = value;
            newNode.Next = node;
            newNode.Previous = node.Previous;

            node.Previous.Next = newNode;
            node.Previous = newNode;

            this.Length += 1;
        }

        public void AddFirst(T value) => this.InsertBefore(this.First, value);
        public void Add(T value) => this.InsertAfter(this.Last, value);

        public void Remove(LinkedListNode<T> node)
        {
            node.Previous.Next = node.Next;
            node.Next.Previous = node.Previous;

            this.Length -= 1;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var node = this.First;
            while (node != this.Dummy)
            {
                yield return node.Value;
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

    internal class LinkedListNode<T>
    {
        public LinkedListNode<T> Next { get; internal set; }
        public LinkedListNode<T> Previous { get; internal set; }
        public T Value { get; set; }
        public int Index { get; set; }
    }
}
