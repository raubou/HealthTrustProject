using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthTrustProject
{
    public class AddressesMgr
    {
        HealthTrustContext ctx;
        public AddressesMgr()
        {
            ctx = new HealthTrustContext();
        }
        public void Insert(long? Id, Addresses address)
        {
            try
            {
                Contacts contracts = ctx.Contracts.FirstOrDefault(p => p.ID == Id);
                contracts.Address.Add(new Addresses
                {
                    addressType = address.addressType,
                    AddressLine1 = address.AddressLine1,
                    AddressLine2 = address.AddressLine2,
                    City = address.City,
                    StateCode = address.StateCode,
                    Zip = address.Zip
                });
                ctx.SaveChanges();                
            }
            catch (Exception ex)
            {
            }
        }
        public void Update(Addresses address, long? Id)
        {
            try
            {
                Addresses address2 = ctx.Addresses.FirstOrDefault(p => p.ID ==Id);
                address2.addressType = address.addressType;
                address2.AddressLine1 = address.AddressLine1;
                address2.AddressLine2 = address.AddressLine2;
                address2.City = address.City;
                address2.StateCode = address.StateCode;
                address2.Zip = address.Zip;
                ctx.Addresses.Attach(address2);
                ctx.Entry<Addresses>(address2).State = System.Data.Entity.EntityState.Modified;
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
                Addresses address = ctx.Addresses.FirstOrDefault(p => p.ID == Id);
                ctx.Addresses.Attach(address);
                ctx.Entry<Addresses>(address).State = System.Data.Entity.EntityState.Deleted;
                ctx.SaveChanges();

            }
            catch (Exception ex)
            {

            }
        }
        public Addresses Get(long? Id)
        {
            Addresses address = null;
            try
            {
                address = ctx.Addresses.FirstOrDefault(p => p.ID == Id);
            }
            catch (Exception ex)
            {

            }
            return address;
        }
        public List<Addresses> GetAll(long? Id)
        {
            Contacts contact = new Contacts();
            try
            {
                contact = ctx.Contracts.FirstOrDefault(p => p.ID == Id);
            }
            catch (Exception ex)
            {

            }
            return contact.Address.ToList();
        }
    }
}