// See https://aka.ms/new-console-template for more information
using System.ComponentModel.Design;
using Npgsql;
using NpgsqlTypes;

Console.WriteLine("Opret bruger igennem C# og PSQL");
Console.Write("Indtast brugernavn: ");
var brugernavn = Console.ReadLine();

Console.Write("Indtast adgangskode: ");
var adgangskode = Console.ReadLine();

if (string.IsNullOrWhiteSpace(adgangskode))
{
    throw new NullReferenceException();
}

var psql = new Connection();
var user = new User();

var hashedAdgangskode = user.HashUserPassword(adgangskode);
try
{
    if (string.IsNullOrWhiteSpace(brugernavn) || string.IsNullOrWhiteSpace(hashedAdgangskode))
    {
        throw new ArgumentNullException();
    }

    psql.CreateUser(brugernavn,hashedAdgangskode);
    Console.WriteLine($"Brugeren {brugernavn} er nu oprettet!");
}
catch (Exception e)
{
    Console.WriteLine($"Der skete en fejl i oprettelsen af brugeren. Fejlbeked: {e.Message}");
}