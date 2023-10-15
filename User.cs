using Npgsql;
using NpgsqlTypes;

class User : DatabaseConnection
{
    public void CreateUser(string username, string password)
    {
        using var connection = Connection;
        connection.Open();

        // Query, der skal udføres
        using var command = new NpgsqlCommand("SELECT CreateUser(@username, @password)", connection);
        
        // Opretter parametre med specifik NpgsqlDbType
        var usernameParam = new NpgsqlParameter("username", NpgsqlDbType.Citext)
        {
            Value = username
        };

        var passwordParam = new NpgsqlParameter("password", NpgsqlDbType.Varchar)
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
        catch (NpgsqlException e)
        {
            // Skriver exception ud fra psql funktion
            Console.WriteLine($"Der skete en fejl. Fejlbesked: {e.Message}");
        }
        {
            connection.Close();
        }
    }

    public int GetUserIdByUsername(string username)
    {
        using var connection = Connection;
        connection.Open();

        using var command = new NpgsqlCommand("SELECT GetUserIdByUsername(@username)", connection);
        var usernameParam = new NpgsqlParameter("username", NpgsqlDbType.Citext)
        {
            Value = username
        };

        command.Parameters.Add(usernameParam);

        try
        {
            var result = Convert.ToInt32(command.ExecuteScalar());
            return result;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Der skete en fejl. Fejlbesked: {e.Message}");
            throw;
        }
        finally
        {
            connection.Close();
        }
    }
}