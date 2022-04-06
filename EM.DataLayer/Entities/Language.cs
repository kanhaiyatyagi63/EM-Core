namespace EM.DataLayer.Entities
{
    public class Language
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<EmployeeLanguage> EmployeeLanguages { get; set; }
    }
}
