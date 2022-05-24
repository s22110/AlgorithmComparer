using System;

namespace AlgorithmComparer
{
    public class Printer
    {
        public void PrintArray(int[] array, string message)
        {
            Console.Write($"{message}: ");
            for (int i = 0; i < array.Length; i++)
            {
                if (i == array.Length - 1)
                {
                    Console.Write(array[i]);
                }
                else
                {
                    Console.Write($"{array[i]}, ");
                }
            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
