using System;
using System.Collections.Generic;

namespace AlgorithmComparer
{
    public class NumberManager
    {
        Random _random;

        public NumberManager()
        {
            _random = new Random();
        }

        public int[] GenerateRandomArray(int arrayLength)
        {
            int[] array = new int[arrayLength];
            for (int i = 0; i < arrayLength; i++)
            {
                array[i] = _random.Next();
            }

            return array;
        }

        public void ReverseArray(int[] array)
        {
            for (int i = 0; i < array.Length / 2; i++)
            {
                int tmp = array[i];
                array[i] = array[array.Length - i - 1];
                array[array.Length - i - 1] = tmp;
            }
        }

        public int[] CopyArray(int[] array)
        {
            return new List<int>(array).ToArray();
        }
    }
}
