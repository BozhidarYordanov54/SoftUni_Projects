using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace CustomStack
{
    
    internal class CustomStack
    {
        private const int InitialCapacity = 4;

        private int[] items;

        public CustomStack() 
        {
            items = new int[InitialCapacity];
        }

       public int Count { get; private set; }

        public void Push(int item)
        {
            if (items.Length == Count)
            {
                Resize();
            }

            items[Count] = item;

            Count++;
        }
        public int Peek()
        {
            if (Count == 0)
            {
                ContainsElements();
            }

            int removedItem = items[Count - 1];

            return removedItem;
        }
        public int Pop() 
        {
            if (Count == 0)
            {
                ContainsElements();
            }

            int removedItem = items[Count - 1];
            Count--;

            return removedItem;
        }
        public void ForEach(Action<object> action)
        {
            for (int i = 0; i < Count; i++)
            {
                int currentItem = items[i];

                action(currentItem);
            }
        }

        private void ContainsElements()
        {
            if (items.Length == 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }
        }

        private void Resize()
        {
            int[] copy = new int[items.Length * 2];

            for (int i = 0; i < Count; i++)
            {
                copy[i] = items[i];
            }

            items = copy;
        }

        
    }
}
