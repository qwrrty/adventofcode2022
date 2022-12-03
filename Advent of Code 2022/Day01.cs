﻿// See https://aka.ms/new-console-template for more information

String inputFileName = "/Users/twp/Downloads/day_01.txt";

List<Elf> elves = new();
List<int> foods = new();

foreach (String line in System.IO.File.ReadLines(inputFileName))
{
    if (line.Length == 0)
    {
        elves.Add(new Elf(foods));
        foods = new();
        continue;
    }
    foods.Add(int.Parse(line));
}

// the elf with the most calories:
Console.WriteLine(elves.OrderByDescending(e => e.TotalCalories())
    .First()
    .TotalCalories());

// the three elves with the most calories:
Console.WriteLine(elves.OrderByDescending(e => e.TotalCalories())
    .Take(3)
    .Sum(e => e.TotalCalories()));

class Elf
{
    public List<int> Foods { get; set; }

    public Elf() { Foods = new List<int>(); }

    public Elf(List<int> data) { Foods = data; }

    public int TotalCalories()
    {
        return Foods.Sum();
    }
}