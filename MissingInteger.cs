using System;
using System.Collections.Generic;
using System.Linq;

namespace exercises
{
    class MissingInteger
    {
        private static List<int> BuildList(string input)
        {
            var currentList = new List<int>();

            //set up the current list
            foreach (string s in input.Split(' '))
            {
                if (int.TryParse(s, out int i))
                    currentList.Add(i);
            }

            return currentList;
        }

        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var currentList = BuildList(input);

            // Remove negative values
            currentList.RemoveAll(i => i < 0);

            //set up the expected range
            var expectedRange = Enumerable.Range(currentList.Min(), currentList.Max());

            //get the missing items
            var missingItems = expectedRange.Except(currentList);

            //print first missing item
            Console.WriteLine(missingItems.FirstOrDefault());

            // wait for user input
            Console.ReadLine();
        }
    }
}
