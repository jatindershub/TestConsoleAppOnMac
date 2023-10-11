// See https://aka.ms/new-console-template for more information
using System.ComponentModel.Design;
using Npgsql;
using NpgsqlTypes;

Console.WriteLine("Tester forbindelse til psql RUC database + Opretter bruger");

var psql = new Connection();

try
{
    psql.CreateUser("test2","kode2");
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}