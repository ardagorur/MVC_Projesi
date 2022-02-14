using ItServiceApp.Core.Entites;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ItServiceApp.Core.Identity
{
    public class ApplicationUser: IdentityUser
    {
        [Required,StringLength(50)]
        [PersonalData]
        public string Name { get; set; }
        [Required, StringLength(50)]
        [PersonalData]
        public string Surname { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public virtual List<Address> Addresses { get; set; }
        public virtual List<Subscription> GetSubscriptions { get; set; }
    }
}
