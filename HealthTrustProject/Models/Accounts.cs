using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthTrustProject
{
    public class Accounts
    {
        public Accounts()
        {

        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }
        [Required]
        [StringLength(140)]
        public string email { get; set; }
        [Required]
        [StringLength(200)]
        public string password { get; set; }
        [Required]
        [StringLength(200)]        
        public string PasswordHash { get; set; }
    }
}