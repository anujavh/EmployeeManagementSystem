using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.Models
{

    [PrimaryKey("Id")]
    public class DepartmentModel
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public required string DepartmentName { get; set; }

        

    }
}
