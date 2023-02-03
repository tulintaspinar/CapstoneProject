using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneProject_EntityLayer.Concrete
{
    public class EmployeeeSalaryPayment
    {
        public int EmployeeeSalaryPaymentId { get; set; }
        public DateTime Date { get; set; }
        public decimal Salary { get; set; }
        public string EmployeeName { get; set; }
    }
}
