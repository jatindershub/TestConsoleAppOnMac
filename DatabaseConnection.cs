using Microsoft.VisualBasic;
using Npgsql;
using NpgsqlTypes;

class Connection
{
    public string Host = "cit.ruc.dk";
    public string Port = "5432";
    public string Username = "cit05";
    public string Password = "qiez7UcmvbMq";
    public string Database = "cit05";    
    
    // todo: flyttes over til User class
    public string HashPassword(string password)
    {
        throw new NotImplementedException();
    }

    public void CreateUser(string username, string password)
    {
        // Sætter connection string
        var connectionString = $"Host={Host};Port={Port};Username={Username};Password={Password};Database={Database}";

        using var connection = new NpgsqlConnection(connectionString);

        connection.Open();

        // Create a command to execute a stored function
        using var command = new NpgsqlCommand("SELECT CreateUser(@username, @password)", connection);
        // Create parameters with specific NpgsqlDbType
        NpgsqlParameter usernameParam = new NpgsqlParameter("username", NpgsqlDbType.Citext)
        {
            Value = username
        };
        NpgsqlParameter passwordParam = new NpgsqlParameter("password", NpgsqlDbType.Varchar)
        {
            Value = password
        };

        // Add parameters to the command
        command.Parameters.Add(usernameParam);
        command.Parameters.Add(passwordParam);

        try
        {
            // Execute the command
            var result = command.ExecuteScalar();
            // Handle the result if your function returns any value
            Console.WriteLine($"Result: {result}");
        }
        catch (NpgsqlException ex)
        {
            // Handle any errors
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
        }
}
