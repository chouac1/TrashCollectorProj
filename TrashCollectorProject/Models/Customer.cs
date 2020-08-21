using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("First Name")]
        public string FirstName {get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [DisplayName("Request a One-Time Pickup")]
        public string OneTimePickup { get; set; }
        [DisplayName("Current Balance")]
        public double Balance { get; set; }
        [DisplayName("Service Start Date")]
        public string StartDate { get; set; }
        [DisplayName("Service End Date")]
        public string EndDate { get; set; }
        [DisplayName("Customer's Address")]
        public string Address { get; set; }
        [DisplayName("Customer's Zipcode")]
        public string Zipcode { get; set; }
        [DisplayName("Pickup Confirmed")]
        public bool isConfirmed { get; set; }

        [ForeignKey("IdentityUser")]
        [DisplayName("User ID")]
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }
    }
}
