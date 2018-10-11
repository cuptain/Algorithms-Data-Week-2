using System;
using System.IO;

namespace Число_инверсий
{
    class Inversion
    {
        public static StreamWriter sw = new StreamWriter("output.txt");
        static long inv = 0;

        static int[] Merge(int[] firstArr, int[] secondArr)
        {
            int i = 0, j = 0;
            int n = firstArr.Length;
            int m = secondArr.Length;
            int[] result = new int[n + m];
            while (i < n && j < m)
            {
                if (firstArr[i] <= secondArr[j])
                {
                    result[i + j] = firstArr[i];
                    inv += j;
                    i++;
                }
                else
                {
                    result[i + j] = secondArr[j];
                    j++;
                }
            }
            while (i < n)
            {
                result[i + j] = firstArr[i];
                inv += j;
                ++i;
            }
            while (j < m)
            {
                result[i + j] = secondArr[j];
                j++;
            }
            return result;
        }

        static void MergeSort(ref int[] arr, int l, int r)
        {
            if (r - l <= 1)
                return;
            int[] left = new int[arr.Length / 2];
            int[] right = new int[arr.Length - left.Length];
            for (int i = 0; i < left.Length; i++)
            {
                left[i] = arr[i];
            }
            int k = 0;
            for (int i = left.Length; i < arr.Length; i++)
            {
                right[k] = arr[i];
                k++;
            }
            MergeSort(ref left, l, (l + r) / 2);
            MergeSort(ref right, (l + r) / 2, r);
            arr = Merge(left, right);
        }

        static void showArr(int[] arr)
        {
            foreach (int elem in arr)
                sw.Write(elem + " ");
        }

        static void Main(string[] args)
        {
            string[] s = File.ReadAllLines("input.txt");
            string[] arr = new string[Int32.Parse(s[0])];
            int[] intArr = new int[arr.Length];
            arr = s[1].Split();
            for (int i = 0; i < arr.Length; i++)
            {
                intArr[i] = Int32.Parse(arr[i]);
            }
            int[] sortedArr = new int[intArr.Length];
            MergeSort(ref intArr, 0, intArr.Length);
            sw.WriteLine(inv);
            sw.Close();
        }
    }
}
