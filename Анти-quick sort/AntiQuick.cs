using System;
using System.IO;

namespace Анти_quick_sort
{
    class Program
    {
        static int[] Swap(int indice1, int indice2, int[] arr)
        {
            int buf = arr[indice1];
            arr[indice1] = arr[indice2];
            arr[indice2] = buf;
            return arr;
        }
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("input.txt");
            StreamWriter sw = new StreamWriter("output.txt");
            string s = sr.ReadLine();
            int n = Int32.Parse(s);
            int[] arr = new int[n];
            int elem = 1;
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = elem;
                if (i >= 2)
                {
                    arr = Swap(i / 2, i, arr);
                }
                elem++;
            }
            foreach (int element in arr)
                sw.Write(element + " ");
            sw.Close();
        }
    }
}
