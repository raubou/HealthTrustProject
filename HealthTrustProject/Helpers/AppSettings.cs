using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Collections.Specialized;

namespace HealthTrustProject
{
    public class AppSettings
    {
        public static string HealthTrustConnection = ConfigurationManager.ConnectionStrings["HealthTrustConnection"].ToString();
        public static bool migrateDB = Convert.ToBoolean(ConfigurationManager.AppSettings["migrateDB"]);
    }
}