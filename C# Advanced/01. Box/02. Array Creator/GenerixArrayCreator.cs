using System;
using System.Collections.Generic;
using System.Text;

namespace GenericArrayCreator
{
    internal class ArrayCreator
    {
        public static T[] Create<T>(int lenght, T element)
        {
            T[] array = new T[lenght];

            for (int i = 0; i < lenght; i++)
            {
                array[i] = element;
            }

            return array;
        }
    }
}
