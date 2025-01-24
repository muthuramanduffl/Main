using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Utility
/// </summary>
public class Utility
{
    public Utility()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static DateTime IndianTime
    {
        get
        {
            return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"));
        }
    }
}