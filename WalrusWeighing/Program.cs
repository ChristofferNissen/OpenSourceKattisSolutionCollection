using System;
using System.Linq;
using System.Collections.Generic;

namespace walrus
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            string line;
            var ns = new int[n];
            int idx = 0;
            while ((line = Console.ReadLine()) != null) 
                ns[idx++] = int.Parse(line);

            var res = KnapSack(1000, ns, ns.Length);
            var l = ns.Min();

            if (Math.Abs(1000-res) >= Math.Abs(1000-(res+l)) && res + l > 1000)
                System.Console.WriteLine(res + l);
            else
                System.Console.WriteLine(res);
        }

         public static int KnapSack(int capacity, int[] weight, int itemsCount)
        {
            int[,] K = new int[itemsCount + 1, capacity + 1];
 
            for (int i = 0; i <= itemsCount; ++i)
            {
                for (int w = 0; w <= capacity; ++w)
                {
                    if (i == 0 || w == 0)
                        K[i, w] = 0;
                    else if (weight[i - 1] <= w)
                        K[i, w] = Math.Max(weight[i - 1] + K[i - 1, w - weight[i - 1]], K[i - 1, w]);
                    else
                        K[i, w] = K[i - 1, w];
                }
            }
 
            return K[itemsCount, capacity];
        }
    }
}
