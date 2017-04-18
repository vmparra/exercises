using System;
using System.Linq;

namespace exercises
{
    class BiggerInt
    {
        private static int[] BuildList(string input)
        {
            var splittedList = input.Split(' ');

            var count = splittedList.Count() - 1;

            var currentList = new int[count];

            //set up the current list
            for (int i = 0; i < count; i++)
            {
                if (int.TryParse(splittedList[i], out int val))
                    currentList[i] = val;
            }

            return currentList;
        }

        public static int GetLargest(int[] numbers)
        {
            if (numbers.Length == 1)
            {
                return numbers[0];
            }
            else
            {
                int largest = 0;
                for (int i = 0; i < numbers.Length; i++)
                {
                    int[] other = numbers.Take(i).Concat(numbers.Skip(i + 1)).ToArray();
                    int n = Int32.Parse(numbers[i].ToString() + GetLargest(other).ToString());
                    if (i == 0 || n > largest)
                    {
                        largest = n;
                    }
                }
                return largest;
            }
        }

        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var orderedList = BuildList(input);

            // Calculates largest value
            var result = GetLargest(orderedList);

            //print value
            Console.WriteLine(result);

            // wait for user input
            Console.ReadLine();
        }
    }
}