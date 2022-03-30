using System.ComponentModel.DataAnnotations;

namespace EM.Web.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Employee name is required!"),
         MaxLength(10, ErrorMessage = "Employee name must be less than equal to 10"),
         Display(Name = "Employee Name", Prompt = "Enter Employee Name"),
         MinLength(3, ErrorMessage = "Employee name length must be greater than or equal 2")]
        public string Name { get; set; }

        [Display(Name = "D.O.B", Prompt = "Enter Date Of Birth")]
        public DateTime DateOfBirth { get; set; }
    }
}
