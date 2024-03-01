using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Chapter10
{
    public class Queue<T>
    {
        private Node<T>? _head;
        private Node<T>? _tail;
        private int _count;

        private class Node<TData>
        {
            public TData Data { get; set; }
            public Node<TData>? Next { get; set; }

            public Node(TData data)
            {
                Data = data;
                Next = null;
            }
        }

        public Queue()
        {
            _head = null;
            _tail = null;
            _count = 0;
        }

        public int Count => _count;

        public void Enqueue(T item)
        {
            Node<T> newNode = new Node<T>(item);
            if (_tail == null)
            {
                _head = _tail = newNode;
            }
            else
            {
                _tail.Next = newNode;
                _tail = newNode;
            }
            _count++;
        }

        public T Dequeue()
        {
            if (_head == null)
            {
                throw new InvalidOperationException("Queue is empty.");
            }

            Node<T> temp = _head;
            _head = _head.Next;

            if (_head == null)
            {
                _tail = null;
            }

            _count--;
            return temp.Data;
        }
    }
}
