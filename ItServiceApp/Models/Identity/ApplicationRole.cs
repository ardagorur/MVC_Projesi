using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItServiceApp.Models.Identity
{
    public class ApplicationRole:IdentityRole
    {
        public ApplicationRole()
        {

        }
        public ApplicationRole(string name, string description)
        {
            this.Name = name;
            this.Description = description;
        }
        public string Description { get; set; }
    }
}
