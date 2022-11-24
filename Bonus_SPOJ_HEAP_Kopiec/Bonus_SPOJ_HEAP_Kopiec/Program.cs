using System;
using System.Text;

namespace HEAP
{
    internal class Program
    {
        static void Print(int[] heap)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var leaf in heap)
            {
                sb.Append(leaf + " ");
            }
            Console.WriteLine(sb.ToString());
        }
        static void Heapify(ref int[] heap, int n, int i)
        {
            int min = i;
            int l = 2 * i + 1;
            int r = 2 * i + 2;

            if (l <= n && heap[l] < heap[min])
            {
                min = l;
            }

            if (r <= n && heap[r] < heap[min])
            {
                min = r;
            }

            if (min != i)
            {

                int tmp = heap[i];
                heap[i] = heap[min];
                heap[min] = tmp;
                Heapify(ref heap, n, min);
            }
        }
        static void BuildHeap(ref int[] heap)
        {
            for (int i = heap.Length / 2; i >= 0; i--)
            {
                Heapify(ref heap, heap.Length - 1, i);
            }
        }
        public static void Main(string[] args)
        {
            int tests = int.Parse(Console.ReadLine());
            int[][] heaps = new int[tests][];
            char[][] arr = new char[tests][];

            for (int itr = 0; itr < tests; ++itr)
            {
                bool check1;
                bool check2;
                int n;
                int m;

                do
                {
                    check1 = int.TryParse(Console.ReadLine(), out n);
                } while (!check1);

                heaps[itr] = new int[n];

                for (int i = 0; i < n; ++i)
                    heaps[itr][i] = int.Parse(Console.ReadLine());
                do
                {
                    check2 = int.TryParse(Console.ReadLine(), out m);
                } while (!check2);

                arr[itr] = new char[m];
                for (int i = 0; i < m; ++i)
                    arr[itr][i] = char.Parse(Console.ReadLine());
            }

            for (int i = 0; i < tests; ++i)
            {
                BuildHeap(ref heaps[i]);
                foreach (var x in arr[i])
                {

                    if (x == 'P')
                    {
                        Print(heaps[i]);
                    }
                    else
                    {
                        Console.WriteLine(RemoveMin(ref heaps[i]));
                        BuildHeap(ref heaps[i]);
                    }
                }
            }
        }
        static int RemoveMin(ref int[] heap)
        {
            int last = heap.Length - 1;

            var tmp = heap[0];
            heap[0] = heap[last];
            heap[last] = tmp;

            int rem = heap[last];

            int[] heap2 = new int[last];

            for (int i = 0; i < last; ++i)
            {
                heap2[i] = heap[i];
            }

            heap = heap2;
            return rem;
        }
    }
}