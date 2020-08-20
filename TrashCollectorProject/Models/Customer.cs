using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace TrashCollectorProject.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string FirstName {get; set; }
        public string LastName { get; set; }
        public string OneTimePickup { get; set; }
        public double Balance { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Address { get; set; }
        public string Zipcode { get; set; }
        public bool isConfirmed { get; set; }

        [ForeignKey("IdentityUser")]
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }
    }
}
