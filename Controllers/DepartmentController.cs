using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        // GET: api/Department
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RespDepartmentDto>>> GetAllDepartments()
        {

            var result = await _departmentService.GetAllDepartments();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // GET: api/Department/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RespDepartmentDto>> GetByDeptId(int id)
        {
            var result = await _departmentService.GetByDeptId(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // PUT: api/Department/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDepartmentDetails(int id, ReqDepartmentDto departmentModel)
        {
            var result = await _departmentService.UpdateDepartmentDetails(id, departmentModel);
            if (result == null)
                return NoContent();
            return Ok(result);
        }

        // POST: api/Department
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DepartmentModel>> AddDepartmentDetailsAsync(ReqDepartmentDto departmentModel)
        {
            var result = await _departmentService.AddDepartmentDetailsAsync(departmentModel);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        // DELETE: api/Department/5
        [HttpDelete("{id}")] 
        public async Task<IActionResult> DeleteDepartmentDetails(int id)
        {
            var result = await _departmentService.DeleteDepartmentDetails(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

    }
}
