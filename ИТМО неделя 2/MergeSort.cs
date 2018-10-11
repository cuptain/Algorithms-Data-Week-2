using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ИТМО_неделя_2
{
    class MergeSort
    {
        public static StreamWriter sw = new StreamWriter("output.txt");
        static int[] Merge(int[] firstArr, int[] secondArr)
        {
            int i = 0, j = 0;
            int n = firstArr.Length;
            int m = secondArr.Length;
            int[] result = new int[n + m];
            while (i < n && j < m)
            {
                if (firstArr[i] < secondArr[j])
                {
                    result[i + j] = firstArr[i];
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
                ++i;
            }
            while (j < m)
            {
                result[i + j] = secondArr[j];
                j++;
            }
            return result;
        }

        static void Merge(ref int[] arr, int l, int r)
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
            Merge(ref left, l, (l + r) / 2);
            Merge(ref right, (l + r) / 2, r);
            arr = Merge(left, right);
            sw.WriteLine("{0} {1} {2} {3}", l + 1, r, arr[0], arr[arr.Length - 1]);
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
            Merge(ref intArr, 0, intArr.Length);
            showArr(intArr);
            sw.Close();
        }
    }
}
