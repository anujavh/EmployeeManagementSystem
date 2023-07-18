using EmployeeManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public EmployeeService(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        async Task<ServiceResponse<List<RespEmployeeDto>>> IEmployeeService.GetAllEmployees()
        {
            var serviceResponse = new Models.ServiceResponse<List<RespEmployeeDto>>();
            try
            {
                var result = await _dataContext.EmployeeModels.ToListAsync();
                serviceResponse.Data = _mapper.Map<List<RespEmployeeDto>>(result);
                return serviceResponse;
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message.ToString();
                return serviceResponse;
            }
        }

        async Task<ServiceResponse<RespEmployeeDto>> IEmployeeService.GetByEmployeeId(int EmployeeId)
        {
            var serviceResponse = new Models.ServiceResponse<RespEmployeeDto>();
            try
            {
                if (!EmployeeModelExists(EmployeeId))
                {
                    throw new Exception("Employee ID not found");
                }
                var result = await _dataContext.EmployeeModels.FirstOrDefaultAsync(x => x.EmpId == EmployeeId);
                if (result is null)
                {
                    throw new Exception($"Employee ID '{EmployeeId}' not found");
                }
                serviceResponse.Data = _mapper.Map<RespEmployeeDto>(result);
                return serviceResponse;
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message.ToString();
                return serviceResponse;
            }
        }

        async Task<ServiceResponse<EmployeeModel>> IEmployeeService.AddEmployeeDetailsAsync(ReqEmployeeDto reqEmployeeDetails)
        {
            var serviceResponse = new Models.ServiceResponse<EmployeeModel>();
            try
            {
                if (!DepartmentModelExists(reqEmployeeDetails.DepartmentId))
                {
                    throw new Exception($"Department ID '{reqEmployeeDetails.DepartmentId}' not found");
                }
                var result = await _dataContext.EmployeeModels.AddAsync(_mapper.Map<EmployeeModel>(reqEmployeeDetails));               
                await _dataContext.SaveChangesAsync();
                if (result == null)
                    throw new Exception("Error occurred while saving the data");

                serviceResponse.Data = _mapper.Map<EmployeeModel>(reqEmployeeDetails);
                return serviceResponse;
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message.ToString();
                return serviceResponse;
            }
        }

        async Task<ServiceResponse<EmployeeModel>> IEmployeeService.UpdateEmployeeDetails(int EmployeeId, ReqEmployeeDto requestEmployeeDetails)
        {
            var serviceResponse = new Models.ServiceResponse<EmployeeModel>();
            try
            {
                if (!EmployeeModelExists(EmployeeId))
                {
                    throw new Exception("Employee ID not found");
                }

                var result = await _dataContext.EmployeeModels.FirstOrDefaultAsync(x => x.EmpId == EmployeeId);
                if (result is null)
                {
                    throw new Exception($"Employee ID '{EmployeeId}' not found");
                }
                if (!DepartmentModelExists(requestEmployeeDetails.DepartmentId))
                {
                    throw new Exception($"Department ID '{requestEmployeeDetails.DepartmentId}' not found");
                }
                result.EmployeeName = requestEmployeeDetails.EmployeeName;
                result.Salary = requestEmployeeDetails.Salary;
                result.Age = requestEmployeeDetails.Age;
                result.DepartmentId = requestEmployeeDetails.DepartmentId;


                serviceResponse.Data = _mapper.Map<EmployeeModel>(result);
                await _dataContext.SaveChangesAsync();
                return serviceResponse;
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message.ToString();
                return serviceResponse;
            }
        }

        async Task<ServiceResponse<EmployeeModel>> IEmployeeService.DeleteEmployeeDetails(int EmployeeId)
        {
            var serviceResponse = new Models.ServiceResponse<EmployeeModel>();
            try
            {
                var empModel = await _dataContext.EmployeeModels.FindAsync(EmployeeId);
                if (empModel != null)
                {
                    _dataContext.EmployeeModels.Remove(empModel);
                    await _dataContext.SaveChangesAsync();
                    serviceResponse.Data = empModel;
                    return serviceResponse;
                }
                else
                    throw new Exception("Employee ID not found");
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message.ToString();
                return serviceResponse;
            }
        }

        private bool EmployeeModelExists(int employeeId)
        {
            return (_dataContext.EmployeeModels?.Any(e => e.EmpId == employeeId)).GetValueOrDefault();
        }

        private bool DepartmentModelExists(int id)
        {
            return (_dataContext.DepartmentModels?.Any(e => e.Id == id)).GetValueOrDefault();
        }

    }
}
