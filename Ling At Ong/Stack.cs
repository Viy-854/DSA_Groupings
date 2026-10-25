using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DSA
{
    public class Stack
    {
        private int[] _stackArray = new int[5];
        private int _top;
        private int _maxSize;

        public Stack(int size)
        {
            _maxSize = size > 0 ? size : 5;
            _stackArray = new int[_maxSize];
            _top = -1;
        }
        public bool isEmpty()
        {
            return _top == -1;
        }
        public bool isFull()
        {
            return _top == _maxSize - 1;
        }
        public void Push(int item)
        {
            _stackArray[++_top] = item;
            Console.WriteLine($"Pushed {item} to stack.");
        }
        public int Peek()
        {
            if (isEmpty())
                throw new InvalidOperationException("Stack is empty: nothing to peek.");
            return _stackArray[_top];
        }
        public void Pop()
        {
            try
            {
                Log("Peek: top is " + Peek());
            }
            catch (InvalidOperationException ex)
            {
                Log(ex.Message);
            }

            int poppedItem = _stackArray[_top--];
            Console.WriteLine($"Popped {poppedItem} from stack.");
        }

        private void Log(object value)
        {
            throw new NotImplementedException();
        }

        public int[] Display()
        {
            int[] items = new int[_top + 1];
            for (int i =_top, j = 0; i>=0;i--, j++)
            {
                items[j] = _stackArray[i];
            }
            return items;
        }
    }
}
