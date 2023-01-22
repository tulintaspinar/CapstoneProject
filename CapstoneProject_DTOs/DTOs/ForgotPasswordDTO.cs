using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneProject_DTOs.DTOs
{
    public class ForgotPasswordDTO
    {
        public string Email { get; set; }
        public string ForgotPasswordCode { get; set; }
        public string Password { get; set; }
    }
}
