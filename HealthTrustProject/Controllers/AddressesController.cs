using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;

namespace HealthTrustProject.Controllers
{
    [Authorize]
    public class AddressesController : BaseController
    {
        AddressesMgr adm;
        public AddressesController()
        {
            adm = new AddressesMgr();
        }
        // GET: Addresses
        public ActionResult Index(long? Id)
        {
            if (Id == null || Id == 0)
                return RedirectToAction("Index", "Contacts");
            List<Addresses> Address = adm.GetAll(Id);
            return View(Address);
        }
        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Insert(long? Id, Addresses address)
        {
            if (address == null || Id == null)
                return RedirectToAction("Index", "Contacts");
            adm.Insert(Id, address);
            return Content("Success", "text/html");
        }
        [HttpPost]
        public async Task<ActionResult> Delete(long? Id)
        {
            if (Id == null || Id == 0)
                return RedirectToAction("Index", "Contacts");
            adm.Delete(Id);
            return RedirectToAction("Index", "Contacts");
        }
        public async Task<ActionResult> Update(long? Id)
        {
            if (Id == null || Id == 0)
                return RedirectToAction("Index", "Contacts");
            Addresses address = adm.Get(Id);
            return View("Update", address);
        }
        [HttpPost]
        public async Task<ActionResult> Update(Addresses address,long? Id)
        {
            if (address == null)
                return RedirectToAction("Index", "Contacts");
            adm.Update(address, Id);
            return Content("Success", "text/html");
        }
        public ActionResult Search()
        {
            return View("Index");
        }
        [HttpPost]
        public async Task<ActionResult> Search(string firstName, string lastName)
        {
            return View();
        }
       
        public ActionResult SearchResult(List<Addresses> Addresses)
        {
            return View();
        }
    }
}