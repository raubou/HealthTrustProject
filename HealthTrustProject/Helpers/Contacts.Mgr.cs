using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace HealthTrustProject
{
    public class ContactsMgr
    {
        HealthTrustContext ctx;
        public ContactsMgr()
        {
            ctx = new HealthTrustContext();
        }
        public void Insert(Contacts contact)
        {
            try
            {
                ctx.Contracts.Add(contact);
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
            }
        }
        public void Update(Contacts contact)
        {
            try
            {
                    ctx.Contracts.Attach(contact);
                    ctx.Entry<Contacts>(contact).State = System.Data.Entity.EntityState.Modified;
                    ctx.SaveChanges();
            }
            catch (Exception ex)
            {

            }
        }
        public void Delete(long? Id)
        {
            try
            {
                Contacts contact = ctx.Contracts.FirstOrDefault(p => p.ID == Id);
                ctx.Contracts.Attach(contact);
                ctx.Entry<Contacts>(contact).State = System.Data.Entity.EntityState.Deleted;
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {

            }
        }
        public Contacts Get(long? Id)
        {
            Contacts contacts = null;
            try
            {
                contacts = ctx.Contracts.FirstOrDefault(p => p.ID == Id);
            }
            catch (Exception ex)
            {

            }
            return contacts;
        }
        public List<Contacts> Get()
        {
            List<Contacts> Contacts = new List<Contacts>();
            try
            {
                Contacts = ctx.Contracts.ToList();
            }
            catch (Exception ex)
            {

            }
            return Contacts;
        }
        public List<Contacts> Get(string firstName, string lastName)
        {
            List<Contacts> Contacts = new List<Contacts>();
            try
            {
                Contacts = ctx.Contracts.ToList();
            }
            catch (Exception ex)
            {

            }
            return Contacts;
        }
    }
}