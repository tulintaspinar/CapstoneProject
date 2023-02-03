using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneProject_EntityLayer.Concrete
{
    public class AppUser : IdentityUser<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Image { get; set; }
        public int Age { get; set; }
        public decimal Salary { get; set; }
        public string EmailConfirmedCode { get; set; }
        public string ForgotPasswordCode { get; set; }
        public DateTime JoinDate { get; set; }
        public string Job { get; set; }
    }
}
