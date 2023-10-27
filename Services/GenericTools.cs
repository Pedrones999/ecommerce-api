using Microsoft.AspNetCore.Mvc;

namespace GenericTools;
public static class GenericTools
{
    static public string errorFilter(Exception error)
    {
            if(error.Message.Contains("MySQL"))
            {
                return "Database is off!";
            }
            return error.Message;
    }
}
