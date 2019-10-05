using System;
using System.Collections.Generic;
using System.Linq;

namespace PlantingTreesKattis
{
    class BankQueue
    {
        static int Min(int a, int b)
        {
            return ((a < b) ? a : b);
        }

        static int Max(int a, int b)
        {
            return (a > b) ? a : b;
        }

        static void Main(string[] args)
        {
            var firstLine = Console.ReadLine().Split(" ");
            int peopleCount = int.Parse(firstLine[0]);
            int closingMinutsCount = int.Parse(firstLine[1]);

            int[] amount = new int[48];

            for(int i = 0; i < peopleCount; ++i)
            {
                var line = Console.ReadLine().Split(" ");

                int c = int.Parse(line[0]);
                int t = int.Parse(line[1]);

                for(int p = t; c > 0 && p >= 0; --p)
                {
                    int b = amount[p];
                    amount[p] = Max(c, b);
                    c = Min(c, b); // loop through all earlier spots in the queue, to determine if this customer needs a spot
                }
            }

            int res = 0;
            for(int p = 0; p < closingMinutsCount; ++p)
            {
                res += amount[p];
            }

            Console.WriteLine(res);

        }
    }
}
