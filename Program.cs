// See https://aka.ms/new-console-template for more information
var user = new User();
var helper = new Helper();

Console.WriteLine("Opret bruger igennem C# og PSQL");
Console.Write("Indtast brugernavn: ");
var brugernavn = Console.ReadLine();

Console.Write("Indtast adgangskode: ");
var adgangskode = Console.ReadLine();

try
{
    if (string.IsNullOrWhiteSpace(brugernavn) || string.IsNullOrWhiteSpace(adgangskode))
    {
        throw new ArgumentNullException();
    }

    var hashedAdgangskode = helper.Hash(adgangskode);

    user.CreateUser(brugernavn,hashedAdgangskode);
    Console.WriteLine($"Brugeren {brugernavn} er nu oprettet!");
    Console.WriteLine("Bruger id er: " + user.GetUserIdByUsername(brugernavn).ToString());
}
catch (ArgumentNullException)
{
    Console.WriteLine("Brugernavn eller adgangskode må ikke være null");
}
catch (Exception e)
{
    Console.WriteLine($"Der skete en ukendt fejl i oprettelsen af brugeren. Fejlbeked: {e.Message}");
}