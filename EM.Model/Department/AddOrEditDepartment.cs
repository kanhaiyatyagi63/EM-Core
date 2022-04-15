using System.ComponentModel.DataAnnotations;

namespace EM.Models.Department
{
    public class AddOrEditDepartment
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
