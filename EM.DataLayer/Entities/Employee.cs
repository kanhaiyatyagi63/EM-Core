namespace EM.DataLayer.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string JobTitle { get; set; }

        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; }
        public virtual Address Address { get; set; }

        public virtual ICollection<EmployeeLanguage> EmployeeLanguages { get; set; }
    }
}
