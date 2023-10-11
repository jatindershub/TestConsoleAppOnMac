using System.Reflection.Metadata.Ecma335;
using Microsoft.VisualBasic;
using Npgsql;
using NpgsqlTypes;

class Connection
{
    protected string Host = "cit.ruc.dk";
    protected string Port = "5432";
    protected string Username = "cit05";
    protected string Password = "qiez7UcmvbMq";
    protected string Database = "cit05";    

    private NpgsqlConnection GetConnection()
    {
        var connectionString = $"Host={Host};Port={Port};Username={Username};Password={Password};Database={Database}";
        return new NpgsqlConnection(connectionString);
    }

    public void CreateUser(string username, string password)
    {
        using var connection = GetConnection();
        connection.Open();

        // Query, der skal udføres
        using var command = new NpgsqlCommand("SELECT CreateUser(@username, @password)", connection);
        
        // Opretter parametre med specifik NpgsqlDbType
        NpgsqlParameter usernameParam = new NpgsqlParameter("username", NpgsqlDbType.Citext)
        {
            Value = username
        };

        NpgsqlParameter passwordParam = new NpgsqlParameter("password", NpgsqlDbType.Varchar)
        {
            Value = password
        };

        // Sætter parametrene til query'en
        command.Parameters.Add(usernameParam);
        command.Parameters.Add(passwordParam);

        try
        {
            // Udfører query
            var result = command.ExecuteScalar();
            Console.WriteLine($"Result: {result}");
        }
        catch (NpgsqlException ex)
        {
            // Skriver exception ud fra psql
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
        }
}
