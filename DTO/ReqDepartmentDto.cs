using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.DTO
{
    public class ReqDepartmentDto
    {

        [MaxLength(50)]
        public required string DepartmentName { get; set; }

    }
}
