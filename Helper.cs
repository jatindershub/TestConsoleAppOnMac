using System.Security.Cryptography;
using System.Text;

public class Helper
{
    public string Hash(string password)
    {
        // Convert the input string to a byte array
        byte[] data = Encoding.UTF8.GetBytes(password);

        // Create a new instance of the SHA256 class
        using SHA256 sha256Hash = SHA256.Create();

        // Compute the hash
        byte[] hash = sha256Hash.ComputeHash(data);

        // Convert the byte array to a hexadecimal string
        StringBuilder hashStringBuilder = new StringBuilder();

        for (int i = 0; i < hash.Length; i++)
        {
            hashStringBuilder.Append(hash[i].ToString("x2"));
        }

        string hashedPassword = hashStringBuilder.ToString();
        
        return hashedPassword;
    }
}