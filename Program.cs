using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        string ValA = "Per-Ole Andre Nygaard Falster Jensen";
        string ValB = "Per-Ole André Simon Ñygård";

        var replacements = new Dictionary<string, string>
        {
            { "aa", "å" },
            { "ae", "æ" },
            { "ñ", "n" },
            { "é", "e" },
            { "-", " " }
        };

        // Replace special characters
        ValA = ValA.ToLower();
        ValB = ValB.ToLower();
        foreach (var pair in replacements)
        {
            ValA = ValA.Replace(pair.Key, pair.Value);
            ValB = ValB.Replace(pair.Key, pair.Value);
        }

        // Count matching words
        var wordsA = ValA.Split(' ').ToList();
        var wordsB = ValB.Split(' ').ToList();
        int matchingWordsCount = wordsA.Intersect(wordsB).Count();

        // Check if the first word contains a hyphen
        bool starterMedBindestregA = wordsA.FirstOrDefault() != null && wordsA.First().Contains("-");
        bool starterMedBindestregB = wordsB.FirstOrDefault() != null && wordsB.First().Contains("-");

        Console.WriteLine($"Number of matching words: {matchingWordsCount}");
        Console.WriteLine($"newValA: {ValA}");
        Console.WriteLine($"newValB: {ValB}");
        Console.WriteLine($"StarterMedBindestreg for ValA: {starterMedBindestregA}");
        Console.WriteLine($"StarterMedBindestreg for ValB: {starterMedBindestregB}");
    }
}
