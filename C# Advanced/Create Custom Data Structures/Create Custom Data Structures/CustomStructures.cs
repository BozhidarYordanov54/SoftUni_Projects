using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Create_Custom_Data_Structures
{
    public class CustomList
    {
        private const int InitalCapacity = 2;

        private int[] items;

        public CustomList()
        {
            items = new int[InitalCapacity];
        }
        public int Count { get; private set; }

        public int this[int index]
        { 
            get 
            {
                ValidateIndex(index);
                return items[index]; 
            }
            set
            {
                ValidateIndex(index);
                items[index] = value;
            }
        }
        public void Add(int item)
        {
            if (items.Length == Count)
            {
                Resize();
            }

            items[Count] = item;

            Count++;
        }
        public int RemoveAt(int index)
        {
            ValidateIndex(index);
            int removedItem = items[index];

            items[index] = default(int);

            ShiftLeft(index);

            Count--;

            return removedItem;
        }

        public void InsertAt(int index, int item)
        {
            ValidateIndex(index);
            if (items.Length == Count)
            {
                Resize();
            }

            ShiftRight(index);

            items[index] = item;
            Count++;
        }
        public bool Contains(int item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (items[i] == item)
                {
                    return true;
                }
            }

            return false;
        }
        public void Swap(int firstIndex, int secondIndex)
        {
            ValidateIndex(firstIndex);
            ValidateIndex(secondIndex);

            int temp = items[firstIndex];
            items[firstIndex] = items[secondIndex];
            items[secondIndex] = temp;
        }

        private void Shrink()
        {
            int[] copy = new int[items.Length / 2];

            for (int i = 0; i < Count; i++)
            {
                copy[i] = items[i];
            }

            items = copy;
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
        private void ShiftLeft(int index)
        {
            for (int i = 0; i < Count - 1; i++)
            {
                items[i] = items[i + 1];
            }
        }
        private void ShiftRight(int index)
        {
            for (int i = Count; i > 0; i--)
            {
                items[i] = items[i - 1];
            }
        }
        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    }
}
