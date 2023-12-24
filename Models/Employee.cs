using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace GOSuiteEmployee.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Name")]
        public string EmployeeName { get; set; }
        [DisplayName(" Employee ID")]
        [Required]
        public int? EmployeeId { get; set; }
        [Required]
        public string Title { get; set; }
        [DisplayName("Base Salary")]
        [Required]
        public double Salary { get; set; }
        [Required]
        public int Tenure { get; set; }



    }
}
