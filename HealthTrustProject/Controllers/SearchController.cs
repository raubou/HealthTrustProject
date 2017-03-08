using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HealthTrustProject.Controllers
{
    [AllowAnonymous]
    public class SearchController : BaseController
    {
        // GET: Search
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Contacts contact)
        {
            return Redirect("~/search/searchresults/" + contact.FirstName);
        }
        //[HttpPost]
        public ActionResult SearchResults()
        {
            string name = RouteData.Values["id"].ToString();
            var results = SearchMgr.SearchUsers(name);
            return View(results);
        }
    }
}