using CRUD.Models;
using System.Text.Json.Serialization;

namespace CRUD
{
    public class EmployeeObj : Employee
    {
        public int Id { get; set; }
        public string Department { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }

        [JsonPropertyName("date_of_birth")]
        public DateOnly DateOfBirth { get; set; }

        [JsonPropertyName("employment_date")]
        public DateOnly EmploymentDate { get; set;}
        
        public decimal Salary { get; set; }
    }
}
