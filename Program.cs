// See https://aka.ms/new-console-template for more information

Console.WriteLine("Opret bruger igennem C# og PSQL");
Console.Write("Indtast brugernavn: ");
var brugernavn = Console.ReadLine();

Console.Write("Indtast adgangskode: ");
var adgangskode = Console.ReadLine();

var dbConnection = new DatabaseConnection();
var user = new User();

try
{
    if (string.IsNullOrWhiteSpace(brugernavn) || string.IsNullOrWhiteSpace(adgangskode))
    {
        throw new ArgumentNullException();
    }

    var hashedAdgangskode = user.HashUserPassword(adgangskode);

    dbConnection.CreateUser(brugernavn,hashedAdgangskode);
    Console.WriteLine($"Brugeren {brugernavn} er nu oprettet!");
}
catch (ArgumentNullException)
{
    Console.WriteLine("Brugernavn eller adgangskode må ikke være null");
}
catch (Exception e)
{
    Console.WriteLine($"Der skete en ukendt fejl i oprettelsen af brugeren. Fejlbeked: {e.Message}");
}