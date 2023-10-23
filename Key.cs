using Microsoft.AspNetCore.DataProtection;
using Users.Model;
using System.Security.Cryptography;
using System.Text;


namespace Auth;
public class Keys
{    
     public static string Secret = Guid.NewGuid().ToString();
     public static string Connection = "server=192.168.0.112;database=ECOMMERCE;User=APP;Password=Senha$420";

     public static string? HashingPassword(string toHash)
     {
          try
          {
               using (var sha356 = SHA256.Create())
               {
                    byte[] bytes = sha356.ComputeHash(Encoding.UTF8.GetBytes(toHash));
               
                    var builder = new StringBuilder();
                    for (int i = 0; i < bytes.Length;i++)
                    {
                         builder.Append(bytes[i].ToString("x2"));
                    }
                    
                    return (builder.ToString());
               }
          } 
          catch(Exception error)
          {
               Console.WriteLine(error);
               return (null);
          }
     }
}
