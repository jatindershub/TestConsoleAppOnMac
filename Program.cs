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

try
{
    Console.WriteLine("Indtast et tal");
    int userInput = Convert.ToInt32(Console.ReadLine());   
}
catch (Exception e)
{
    Console.WriteLine("Du har ikke indtastet et tal. Fejlbesked: " + e.Message);
}
