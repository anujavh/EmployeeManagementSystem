using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagementSystem.Models
{

    [PrimaryKey("EmpId")]
    public class EmployeeModel
    {
        public int EmpId { get; set; }

        [MaxLength(30)]
        public required string EmployeeName { get; set; }

        [Range(21, 100, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Age { get; set; }
        public int Salary { get; set; }

        public int DepartmentId { get; set; }
        public DepartmentModel Department { get; set; }



    }
}
