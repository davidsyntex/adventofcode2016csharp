using System;
using System.Collections.Generic;
using System.Linq;

namespace adventofcode2016csharp
{
    internal static class Day01
    {
        private static bool HasVisitedTwice(ICollection<Tuple<int, int>> grid, Tuple<int, int> point)
        {
            return grid != null && point != null && grid.Contains(point);
        }

        internal static void Run()
        {
            Console.WriteLine($"--- Day 1: No Time for a Taxicab ---");
            const string input =
                "R3, L2, L2, R4, L1, R2, R3, R4, L2, R4, L2, L5, L1, R5, R2, R2, L1, R4, R1, L5, L3, R4, R3, R1, L1, L5, L4, L2, R5, L3, L4, R3, R1, L3, R1, L3, R3, L4, R2, R5, L190, R2, L3, R47, R4, L3, R78, L1, R3, R190, R4, L3, R4, R2, R5, R3, R4, R3, L1, L4, R3, L4, R1, L4, L5, R3, L3, L4, R1, R2, L4, L3, R3, R3, L2, L5, R1, L4, L1, R5, L5, R1, R5, L4, R2, L2, R1, L5, L4, R4, R4, R3, R2, R3, L1, R4, R5, L2, L5, L4, L1, R4, L4, R4, L4, R1, R5, L1, R1, L5, R5, R1, R1, L3, L1, R4, L1, L4, L4, L3, R1, R4, R1, R1, R2, L5, L2, R4, L1, R3, L5, L2, R5, L4, R5, L5, R3, R4, L3, L3, L2, R2, L5, L5, R3, R4, R3, R4, R3, R1";
            var instructions = input.Replace(" ", "").Split(',').ToList();

            var facing = 0; // North: 0, East: 1, South: 2, West: 3
            var x = 0;
            var y = 0;

            var grid = new HashSet<Tuple<int, int>> {new Tuple<int, int>(x, y)};

            var ebhq = new EasterBunnyHq();
            var foundEasterBunnyHq = false;

            foreach (var instruction in instructions)
            {
                if (instruction.StartsWith("R"))
                {
                    facing += 1;
                    if (facing > 3)
                    {
                        facing = 0;
                    }
                }
                if (instruction.StartsWith("L"))
                {
                    facing -= 1;
                    if (facing < 0)
                    {
                        facing = 3;
                    }
                }

                var distance = Convert.ToInt32(instruction.Remove(0, 1));
                switch (facing)
                {
                    case 0: // Going North
                    {
                        for (var i = 0; i < distance; i++)
                        {
                            y += 1;
                            var point = new Tuple<int, int>(x, y);
                            if (HasVisitedTwice(grid, point) && foundEasterBunnyHq == false)
                            {
                                foundEasterBunnyHq = true;
                                ebhq.X = point.Item1;
                                ebhq.Y = point.Item2;
                            }
                            grid.Add(point);
                        }
                        break;
                    }
                    case 1: // Going East
                    {
                        for (var i = 0; i < distance; i++)
                        {
                            x += 1;
                            var point = new Tuple<int, int>(x, y);
                            if (HasVisitedTwice(grid, point) && foundEasterBunnyHq == false)
                            {
                                foundEasterBunnyHq = true;
                                ebhq.X = point.Item1;
                                ebhq.Y = point.Item2;
                            }
                            grid.Add(point);
                        }
                        break;
                    }
                    case 2: // Going South
                    {
                        for (var i = 0; i < distance; i++)
                        {
                            y -= 1;
                            var point = new Tuple<int, int>(x, y);
                            if (HasVisitedTwice(grid, point) && foundEasterBunnyHq == false)
                            {
                                foundEasterBunnyHq = true;
                                ebhq.X = point.Item1;
                                ebhq.Y = point.Item2;
                            }
                            grid.Add(point);
                        }
                        break;
                    }
                    case 3: // Going West
                    {
                        for (var i = 0; i < distance; i++)
                        {
                            x -= 1;
                            var point = new Tuple<int, int>(x, y);
                            if (HasVisitedTwice(grid, point) && foundEasterBunnyHq == false)
                            {
                                foundEasterBunnyHq = true;
                                ebhq.X = point.Item1;
                                ebhq.Y = point.Item2;
                            }
                            grid.Add(point);
                        }
                        break;
                    }
                    default:
                    {
                        break;
                    }
                }
            }
            var endPoint = Math.Abs(x) + Math.Abs(y);
            var easterBunnyHqDistance = Math.Abs(ebhq.X) + Math.Abs(ebhq.Y);

            Console.WriteLine($"Distance to EndPoint: {endPoint}");
            Console.WriteLine($"Distance to Easter Bunny HQ: {easterBunnyHqDistance}");
        }

        private class EasterBunnyHq
        {
            public int X;
            public int Y;
        }
    }
}