using System.ComponentModel.DataAnnotations;

namespace EM.Models.Employee
{
    public class EmployeeAddModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Employee name is required"),
         MinLength(3), MaxLength(25)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Gender is required")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Date of birth is required."),
         Display(Name = "Date of Birth", Prompt = "Enter date of birth")]
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "Job title is required"),
         MinLength(3), MaxLength(25),
         Display(Name = "Job Title", Prompt = "Please eneter job title")]
        public string JobTitle { get; set; }
        [Display(Name = "Department"), Required(ErrorMessage = "Department is required")]
        public int DepartmentId { get; set; }

        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        [Display(Name = "Languages"), Required(ErrorMessage = "Select atleast one language")]
        public int[] Languages { get; set; }
    }
}
