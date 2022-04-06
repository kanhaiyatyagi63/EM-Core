using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Models.Employee
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string JobTitle { get; set; }
        public DateTime DateOfBirth { get; set; } 
    }
}
