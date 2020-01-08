using System;

namespace Puzzle1
{
    public class Program
    {
        static void Main(string[] args)
        {
            var sum = 0;
            for (var number = 1; number < 1000; number++)
            {
                if (number % 3 == 0 || number % 5 == 0)
                {
                    sum += number;
                }
            }
            Console.WriteLine(sum);
        }
    }
}
