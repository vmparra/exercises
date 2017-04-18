using System;
using System.Linq;

namespace exercises
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            input.Split(' ').Reverse().ToList().ForEach(s => Console.Write(s + ' '));

            // wait for user input
            Console.ReadKey();
        }
    }
}