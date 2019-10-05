using System;
using System.Collections.Generic;

namespace BinaryOrDecimalCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstLine = Console.ReadLine().Split(" ");
            var d1 = int.Parse(firstLine[0]);
            var d2 = int.Parse(firstLine[1]);

            // setup our playing field
            var patternLines = Read(d1);
            var field = new int[d1, d2];
            for(int i = 0; i < d1; i++)
            {
                int y = 0;
                foreach(int value in ConvertStringToIntArray(patternLines[i]))
                {
                    field[i, y++] = value;
                }
            }
            
            // now field should be all set

            // create array to hold group data, and init group numbers to -1
            var disjoint = new int[d1*d2];
            for (int i = 0; i < disjoint.Length; i++)
                disjoint[i] = -1;
            
            // add each in the array to Union Find (two should be merged, if the value of the field are the same)
            for (int i = 0; i < d1; i++)
            {
                for(int j = 0; j < d2; j++)
                {
                    int ti, tj;

                    ti = i + 1;
                    tj = j;
                    if (InRange(d1, d2, ti, tj) && field[i, j] == field[ti, tj])
                    {
                        Join(disjoint, i * d2 + j, ti * d2 + tj);
                    }

                    ti = i;
                    tj = j + 1;
                    if (InRange(d1, d2, ti, tj) && field[i, j] == field[ti, tj])
                    {
                        Join(disjoint, i * d2 + j, ti * d2 + tj);
                    }

                }
            }

            // parse number of paths, and paths
            var numberOfPaths = int.Parse(Console.ReadLine());
            var pathLines = Read(numberOfPaths);

            // process paths
            foreach(string pathString in pathLines)
            {
                // check if the two points are in the same group, if no print which
                var arrPath = pathString.Split(" ");
                var (r1, c1) = (int.Parse(arrPath[0]) -1, int.Parse(arrPath[1]) - 1);   // start
                var (r2, c2) = (int.Parse(arrPath[2]) -1, int.Parse(arrPath[3]) - 1);   // end

                if (Find(disjoint, r1*d2+c1) == Find(disjoint, r2*d2+c2))
                {
                    if (field[r1, c1] == 1)
                    {
                        Console.Out.WriteLine("decimal");
                    }
                    else
                    {
                        Console.Out.WriteLine("binary");
                    }
                }
                else
                {
                    Console.Out.WriteLine("neither");
                }
            }


        }

        static bool InRange(int x, int y, int ti, int tj)
        {
            if (ti < 0)
            {
                return false;
            }
            if (tj < 0)
            {
                return false;
            }

            if (ti >= x)
            {
                return false;
            }
            if (tj >= y)
            {
                return false;
            }

            return true;
        }

        static int Find(int[] disjoint, int a)
        {
            // default case
            if(disjoint[a] == -1)
            {
                return a;
            }

            disjoint[a] = Find(disjoint, disjoint[a]);
            return disjoint[a];
        }

        static void Join(int[] disjoint, int a, int b)
        {
            a = Find(disjoint, a);
            b = Find(disjoint, b);

            if (a == b)
                return;

            disjoint[a] = b;

        }

        static List<string> Read(int n)
        {
            var list = new List<string>();
            for (int i = 0; i < n; i++)
                list.Add(Console.ReadLine());
            return list;
        }

        static IEnumerable<int> ConvertStringToIntArray(string s)
        {
            for (int i = 0; i < s.Length; i++)
                yield return int.Parse(s.Substring(i, 1));
        }

    }
}
