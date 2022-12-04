// This is a mess.
// For another problem, I'd try a little harder to find an elegant or
// more readable solution, but as it is this feels ridiculously
// overengineered, so I'm calling it a day and moving on.

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

        public static int Score_v2(string line)
        {
            // Score a play according to Day 2 part 2
            // (X means a loss, Y means a draw, Z means a win)

            var shapeValues = new Dictionary<string, int>
            {
                { "A", 1 },
                { "B", 2 },
                { "C", 3 }
            };
            var outcomeScores = new Dictionary<string, int>
            {
                { "X", 0 },
                { "Y", 3 },
                { "Z", 6 }
            };
            var rankedShapes = new string[] { "A", "B", "C" };

            var v = line.Split(' ');
            string shape;

            var i = shapeValues[v[0]] - 1;

            // choose a counter play based on whether we need to lose
            // (X), draw (Y), or win (Z)
            switch (v[1])
            {
                case "X": shape = rankedShapes[(i + 2) % 3]; break;
                case "Z": shape = rankedShapes[(i + 1) % 3]; break;
                default: shape = v[0]; break;
            }

            return shapeValues[shape] + outcomeScores[v[1]];
        }

        public Day02()
        {
            foreach (String line in System.IO.File.ReadLines(inputFileName))
            {
                totalScore += Score_v2(line);
            }
        }

        public int Results()
        {
            return totalScore;
        }
    }
}

