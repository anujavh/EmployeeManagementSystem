namespace EmployeeManagementSystem.Services
{
    public interface IDepartmentService
    {

        public Task<ServiceResponse<List<RespDepartmentDto>>> GetAllDepartments();
        public Task<ServiceResponse<RespDepartmentDto>> GetByDeptId(int DeptId);

        public Task<ServiceResponse<DepartmentModel>> AddDepartmentDetailsAsync(ReqDepartmentDto DeptDetails);
        public Task<ServiceResponse<DepartmentModel>> UpdateDepartmentDetails(int DeptId, ReqDepartmentDto requestDeptDetails);
        public Task<ServiceResponse<DepartmentModel>> DeleteDepartmentDetails(int DeptId);

    }
}
