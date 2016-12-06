using System;

namespace adventofcode2016csharp
{
    internal static class Program
    {
        private static void Main()
        {
            Console.WriteLine("By davidsyntex 2016");
            //Day01.Run();
            Day02.Run();
            Console.ReadLine();
        }
    }

    internal static class Day02
    {
        internal static void Run()
        {
            const string testInput = "ULL,RRDDD,LURDL,UUUUD";
            var instructions = testInput.Split(',');

            // 1 2 3
            // 4 5 6
            // 7 8 9
            
            foreach (var s in instructions)
            {
                Console.WriteLine(s);
            }
        }
    }
}

