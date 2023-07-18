using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.DTO
{
    public class RespEmployeeDto
    {

        public int EmpId { get; set; }

        [MaxLength(30)]
        public required string EmployeeName { get; set; }

        [Range(21, 100, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Age { get; set; }
        public int Salary { get; set; }
        public DepartmentModel? Department { get; set; }
        public int DepartmentId { get; set; }
    }
}
