using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;


namespace HealthTrustProject.Controllers
{
    [Authorize]
    public class ContactsController : BaseController
    {
        ContactsMgr cdm;
        public ContactsController()
        {
            cdm = new ContactsMgr();
        }
        // GET: Contacts
        public ActionResult Index()           
        {
            List<Contacts> Contacts = cdm.Get();
            return View(Contacts);
        }
        [HttpPost]
        public ActionResult Index(Contacts contracts)
        {
            if (contracts == null)
                return RedirectToAction("Index", "Contacts");
            List<Contacts> Contacts = cdm.Get();
            return View(Contacts);
        }
        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Insert(Contacts contracts)
        {
            if (contracts == null)
                return RedirectToAction("Index", "Contacts");
            cdm.Insert(contracts);
            return Content("Success", "text/html");
        }
        public ActionResult Update(long? Id)
        {
            if (Id == null || Id == 0)
                return RedirectToAction("Index", "Contacts");
            Contacts contact = cdm.Get(Id);
            return View(contact);
        }

        [HttpPost]
        public async Task<ActionResult> Update(Contacts contracts)
        {
            if (contracts == null)
                return RedirectToAction("Index", "Contacts");
            cdm.Update(contracts);
            return Content("Success", "text/html");

        }
        [HttpPost]
        public async Task<ActionResult> Delete(long? Id)
        {
            if (Id == null || Id == 0)
                return RedirectToAction("Index", "Contacts");
            cdm.Delete(Id);
            List<Contacts> Contacts = cdm.Get();
            return View("Index",Contacts);
        }

        public ActionResult Search()
        {
            return View("Index");
        }
        [HttpPost]
        public async Task<ActionResult> Search(string firstName, string lastName)
        {
            List<Contacts> Contacts = cdm.Get(firstName, lastName);
            return View("SearchResult", Contacts);
        }
        
        public ActionResult SearchResult(List<Addresses> Addresses)
        {
            return View();
        }
    }
}