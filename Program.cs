// See https://aka.ms/new-console-template for more information

/*var user = new User();
var helper = new Helper();

Console.WriteLine("Indtast 1 for oprettelse af bruger, eller tast 2 for opdatering af adgangskode for bruger");
var response = Console.ReadLine();

if (response == "1")
{   
    Metode1();    
} else
{
    Metode2();
}

void Metode1()
{
    Console.Write("Indtast brugernavn: ");
    string brugernavn = Console.ReadLine();

    Console.Write("Indtast adgangskode: ");
    string adgangskode = Console.ReadLine();

    var hashedAdgangskode = helper.Hash(adgangskode);
    user.CreateUser(brugernavn,hashedAdgangskode);

    var brugerId = user.GetUserIdByUsername(brugernavn);
    Console.WriteLine($"BrugerId for bruger {brugernavn} er {brugerId.ToString()}");
}

void Metode2()
{
    
}*/

/*try

{
    Console.WriteLine("Indtast et tal");
    int userInput = Convert.ToInt32(Console.ReadLine());   
}
catch (Exception e)
{
    Console.WriteLine("Du har ikke indtastet et tal. Fejlbesked: " + e.Message);
}
catch (Exception e)
{
    Console.WriteLine("Du har ikke indtastet et tal. Fejlbesked: " + e.Message);
}
*/

using System;
using System.Collections.Generic;
using System.Linq;

public class StringMatcher
{
    public int CountMatchingWords(string valA, string valB, Dictionary<string, string> replacements)
    {
        valA = ReplaceSpecialCharacters(valA.ToLowerInvariant(), replacements);
        valB = ReplaceSpecialCharacters(valB.ToLower(), replacements);

        var wordsA = valA.Split(' ').ToList();
        var wordsB = valB.Split(' ').ToList();

        return wordsA.Intersect(wordsB).Count();
    }

    public string ReplaceSpecialCharacters(string input, Dictionary<string, string> replacements)
    {
        foreach (var pair in replacements)
        {
            input = input.Replace(pair.Key, pair.Value);
        }

        return input;
    }

    public bool FirstWordContainsBindestreg(string val)
    {
        var firstWord = val.Split(' ').FirstOrDefault();
        return firstWord != null && firstWord.Contains("-");
    }
}

public class Program
{
    public static void Main()
    {
        var matcher = new StringMatcher();

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

        int matchingWordsCount = matcher.CountMatchingWords(ValA, ValB, replacements);

        string newValA = matcher.ReplaceSpecialCharacters(ValA.ToLower(), replacements);
        string newValB = matcher.ReplaceSpecialCharacters(ValB.ToLower(), replacements);

        bool starterMedBindestregA = matcher.FirstWordContainsBindestreg(ValA);
        bool starterMedBindestregB = matcher.FirstWordContainsBindestreg(ValB);

        Console.WriteLine($"Number of matching words: {matchingWordsCount}");
        Console.WriteLine($"newValA: {newValA}");
        Console.WriteLine($"newValB: {newValB}");
        Console.WriteLine($"StarterMedBindestreg for ValA: {starterMedBindestregA}");
        Console.WriteLine($"StarterMedBindestreg for ValB: {starterMedBindestregB}");
    }
}

