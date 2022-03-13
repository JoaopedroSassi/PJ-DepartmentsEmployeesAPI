using System.ComponentModel.DataAnnotations;

namespace DepartmentsCompanies.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "This field is required!")]
        [MaxLength(100, ErrorMessage = "This field has a maximum of 100 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "This field is required!")]
        [MaxLength(12, ErrorMessage = "This field has a maximum of 12 characters")]
        public string RG { get; set; }

        [Required(ErrorMessage = "This field is required!")]
        [Range(1, int.MaxValue, ErrorMessage = "Invalid department")]
        public int DepartmentId { get; set; }
    }
}
