using Npgsql;
using NpgsqlTypes;

class DatabaseConnection
{
    protected string Host = "cit.ruc.dk";
    protected string Port = "5432";
    protected string Username = "cit05";
    protected string Password = "qiez7UcmvbMq";
    protected string Database = "cit05";

    protected NpgsqlConnection Connection
    {
        get
        {
            var connectionString = $"Host={Host};Port={Port};Username={Username};Password={Password};Database={Database}";
            return new NpgsqlConnection(connectionString);
        }
    }
}
