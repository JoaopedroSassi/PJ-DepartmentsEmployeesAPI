using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DepartmentsCompanies.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "This field is required!")]
        [MaxLength(100, ErrorMessage = "This field has a maximum of 100 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "This field is required!")]
        [MaxLength(100, ErrorMessage = "This field has a maximum of 100 characters")]
        public string Initials { get; set; }
    }
}
