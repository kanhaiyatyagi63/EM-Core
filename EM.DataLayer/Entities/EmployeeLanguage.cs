namespace EM.DataLayer.Entities
{
    public class EmployeeLanguage
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int LanguageId { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Language Language { get; set; }
    }
}
