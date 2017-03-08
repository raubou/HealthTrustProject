using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthTrustProject
{
    public class SearchMgr
    {
        public static List<Contacts> SearchUsers(string searchTxt)
        {
            HealthTrustContext ctx = new HealthTrustContext();
            var results = (from w in ctx.Contracts where w.FirstName.Contains(searchTxt) || w.LastName.Contains(searchTxt) || w.EmailAddress.Contains(searchTxt) select w).ToList();
            return results;
        }
    }
}