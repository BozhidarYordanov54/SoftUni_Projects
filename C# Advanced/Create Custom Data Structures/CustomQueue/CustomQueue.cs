using System;
using System.Collections.Generic;
using System.Text;

namespace CustomQueue
{
    internal class CustomQueue
    {
        private int InitialSize = 4;

        private int[] items;

        public CustomQueue() 
        {
            items = new int[InitialSize];
        }

        public int Count { get; private set; }

        public void Enqueue(int item)
        {
            if (items.Length == Count)
            {
                Resize();
            }

            items[Count] = item;
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
