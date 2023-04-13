using System.Security.Cryptography;
using System.Text;
namespace BaikalNews.DAL;

public class Md5
{
    public string HashPassword(string password)
    {
        MD5 md5 = MD5.Create();
        string Salt = "AdMiNsAlT";

        byte[] b = Encoding.ASCII.GetBytes(password+Salt);
        byte[] hash = md5.ComputeHash(b);
        StringBuilder sd = new StringBuilder();
        foreach (var a in hash)
        {
            sd.Append(a.ToString("X2"));
        }

        return sd.ToString();
    }
}