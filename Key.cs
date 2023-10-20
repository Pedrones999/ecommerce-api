using Microsoft.AspNetCore.DataProtection;

namespace Auth;
public class Keys
{    
     public static string Secret = Guid.NewGuid().ToString();
     public static string Connection = "server=192.168.0.112;database=ECOMMERCE;User=APP;Password=Senha$420";
}
