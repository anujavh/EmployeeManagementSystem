using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }


        // GET: api/Employee
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RespEmployeeDto>>> GetAllEmployees()
        {
            var result = await _employeeService.GetAllEmployees();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // GET: api/Employee/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RespEmployeeDto>> GetByEmpId(int id)
        {
            var result = await _employeeService.GetByEmployeeId(id);
            if (result == null)
            {
                return NotFound();
            }         
            return Ok(result);
        }

        // PUT: api/Employee/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployeeDetails(int id, ReqEmployeeDto reqEmployeeDto)
        {
            try
            {
                var result = await _employeeService.UpdateEmployeeDetails(id, reqEmployeeDto);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception)
            {
                throw new Exception("Not Found");
            }
            
        }

        // POST: api/Employee
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EmployeeModel>> AddEmployeeDetailsAsync(ReqEmployeeDto EmployeeModel)
        {
            var result = await _employeeService.AddEmployeeDetailsAsync(EmployeeModel);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // DELETE: api/Employee/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeDetails(int id)
        {
            var result = await _employeeService.DeleteEmployeeDetails(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok();

        }

    }

}