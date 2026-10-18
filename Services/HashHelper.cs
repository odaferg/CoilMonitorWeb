using System.Security.Cryptography;
using System.Text;

namespace CoilMonitorWeb.Helpers;

public static class HashHelper
{
    public static string ComputeSha256(string value)
    {
        using var sha = SHA256.Create();

        var bytes = Encoding.UTF8.GetBytes(value);

        var hashBytes = sha.ComputeHash(bytes);

        return Convert.ToHexString(hashBytes);
    }
}