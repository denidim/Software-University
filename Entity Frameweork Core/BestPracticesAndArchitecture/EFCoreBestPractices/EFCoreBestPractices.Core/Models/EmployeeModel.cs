namespace EFCoreBestPractices.Core.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? MiddleName { get; set; }
        public string JobTitle { get; set; } = null!;
        public DateTime HireDate { get; set; }
        public decimal Salary { get; set; }
    }
}
