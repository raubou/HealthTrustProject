using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthTrustProject 
{
    public class Addresses
    {
        public Addresses()
        {
            //Contact = new Contacts();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }
        [Required]
        public int addressType { get; set; }
        [Required]
        [StringLength(150)]
        public string AddressLine1 { get; set; }
        [Required]
        [StringLength(150)]
        public string AddressLine2 { get; set; }
        [Required]
        [StringLength(150)]
        public string City { get; set; }
        [Required]
        [StringLength(4)]
        public string StateCode { get; set; }
        [Required]
        [StringLength(12)]
        public string Zip { get; set; }
        //[Required]
        //public long ContractId { get; set; }
        public virtual Contacts Contact { get; set; }
    }

    public enum addressType
    {
        Home = 1,
        Work = 2,
        Other = 3
    }
}