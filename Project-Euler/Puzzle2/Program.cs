using System;
using System.Collections.Generic;
using System.Linq;

namespace Puzzle2
{
    class Program
    {
        static void Main(string[] args)
        {
            var evenNumbers = new List<int>();
            var a = 0;
            var b = 1;
            while (true)
            {
                var temp = a;
                a = b;
                b = temp + b;
                if (a > 4000000) break;
                if (a % 2 == 0) evenNumbers.Add(a);
            }
            Console.WriteLine(evenNumbers.Sum());
        }
    }
}
