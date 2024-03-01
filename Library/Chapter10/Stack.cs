using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Chapter10
{
    public class Stack
    {
        private int[] _stack;
        private int _size;
        private int _top;

        public Stack(int inputSize)
        {
            _stack = new int[inputSize];
            _size = inputSize;
            _top = -1;
        }

        public bool IsEmpty()
        {
            if (_top == -1)
            {
                return true;
            }
            return false;
        }

        public void Push(int input)
        {
            if (_top == _size - 1)
            {
                throw new InvalidOperationException("Stack is full.");
            }

            _top++;

            _stack[_top] = input;
        }

        public int Pop() 
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty.");
            }

            _top--;

            return _stack[_top + 1];
        }

        public int[] GetStack()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty.");
            }
            return _stack[.._top];
        }

    }
}
