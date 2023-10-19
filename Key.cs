using Microsoft.AspNetCore.DataProtection;

namespace Auth;
public class ApiKey
{    
     public static string Secret = Guid.NewGuid().ToString();
}
