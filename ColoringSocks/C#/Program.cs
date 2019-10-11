using System;
using System.Linq;

class Program
{

    static void Main(string[] args)
    {
        var globals = Console.ReadLine()
            .Split(" ")
            .Select(a => int.Parse(a))
            .ToArray();

        var socks = Console.ReadLine()
            .Split(" ")
            .Select(s => int.Parse(s))
            .OrderBy(i => i)
            .ToArray();

        int numberOfSocks = globals[0], capacity = globals[1], colorDiff = globals[2];

        int machines = 0, locCount = 0, first = socks[0];

        foreach (var s in socks)
        {
            locCount++;
            if (Math.Abs(first - s) > colorDiff || capacity < locCount)
            {
                locCount = 1;
                machines++;
                first = s;
            }
        }

        if (capacity != 0)
            machines++;

        System.Console.WriteLine(machines);
    }
}

