using System;
namespace Advent_of_Code_2022
{
    public class Day02
    {
        readonly String inputFileName = "/Users/twp/Downloads/day02.txt";

        int totalScore = 0;

        public static int score(string line)
        {
            var shapeValues = new Dictionary<string, int>
            {
                { "X", 1 },
                { "Y", 2 },
                { "Z", 3 }
            };

            var scoreTable = new Dictionary<string, int>
            {
                { "A X", 3 },
                { "A Y", 6 },
                { "A Z", 0 },
                { "B X", 0 },
                { "B Y", 3 },
                { "B Z", 6 },
                { "C X", 6 },
                { "C Y", 0 },
                { "C Z", 3 }
            };

            var v = line.Split(' ');
            return shapeValues[v[1]] + scoreTable[line];
        }

        public Day02()
        {
            foreach (String line in System.IO.File.ReadLines(inputFileName))
            {
                totalScore += score(line);
            }
        }

        public int Results()
        {
            return totalScore;
        }
    }
}

