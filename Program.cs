// See https://aka.ms/new-console-template for more information
var user = new User();
var helper = new Helper();

Console.Write("Indtast brugernavn: ");
string brugernavn = Console.ReadLine();

Console.Write("Indtast adgangskode: ");
string adgangskode = Console.ReadLine();

var hashedAdgangskode = helper.Hash(adgangskode);
user.CreateUser(brugernavn,hashedAdgangskode);

var brugerId = user.GetUserIdByUsername(brugernavn);
Console.WriteLine($"BrugerId for bruger {brugernavn} er {brugerId.ToString()}");