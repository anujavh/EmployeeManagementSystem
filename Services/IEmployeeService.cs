namespace EmployeeManagementSystem.Services
{
    public interface IEmployeeService
    {

        public Task<ServiceResponse<List<RespEmployeeDto>>> GetAllEmployees();
        public Task<ServiceResponse<RespEmployeeDto>> GetByEmployeeId(int EmployeeId);
        public Task<ServiceResponse<EmployeeModel>> AddEmployeeDetailsAsync(ReqEmployeeDto EmployeeDetails);
        public Task<ServiceResponse<EmployeeModel>> UpdateEmployeeDetails(int EmployeeId, ReqEmployeeDto requestEmployeeDetails);
        public Task<ServiceResponse<EmployeeModel>> DeleteEmployeeDetails(int EmployeeId);

    }
}
