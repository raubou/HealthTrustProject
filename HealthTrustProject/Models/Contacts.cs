using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthTrustProject
{
    public class Contacts
    {
        public Contacts()
        {
            Address = new HashSet<Addresses>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }
        [Required]
        [StringLength(50)]        
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required]
        [StringLength(50)]
        public string EmailAddress { get; set; }
        [Required]
        public DateTime Birthdate { get; set; }
        [Required]
        public int NumberOfComputers { get; set; }
        public virtual ICollection<Addresses> Address { get; set; }
}
}