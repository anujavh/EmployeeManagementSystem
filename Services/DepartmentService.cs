
using EmployeeManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public DepartmentService(DataContext dataContext, IMapper mapper)
        {
            _context = dataContext;
            _mapper = mapper;
        }

        async Task<ServiceResponse<List<RespDepartmentDto>>> IDepartmentService.GetAllDepartments()
        {
            var serviceResponse = new Models.ServiceResponse<List<RespDepartmentDto>>();
            try
            {
                var result = await _context.DepartmentModels.ToListAsync();
                serviceResponse.Data = _mapper.Map<List<RespDepartmentDto>>(result);

                if (result != null)
                {
                    return serviceResponse;
                }
                else
                    throw new Exception("Department ID not found");
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message.ToString();
                return serviceResponse;
            }
        }

        async Task<ServiceResponse<RespDepartmentDto>> IDepartmentService.GetByDeptId(int DeptId)
        {
            var serviceResponse = new Models.ServiceResponse<RespDepartmentDto>();
            try
            {
                var result = await _context.DepartmentModels.FirstOrDefaultAsync(x => x.Id == DeptId);
                if (result == null)
                    throw new Exception($"Department ID '{DeptId}' not found");
                serviceResponse.Data = _mapper.Map<RespDepartmentDto>(result);
                return serviceResponse;
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message.ToString();
                return serviceResponse;
            }
        }

        async Task<ServiceResponse<DepartmentModel>> IDepartmentService.AddDepartmentDetailsAsync(ReqDepartmentDto reqDepartmentDto)
        {
            var serviceResponse = new Models.ServiceResponse<DepartmentModel>();
            try
            {
                _context.DepartmentModels.Add(_mapper.Map<DepartmentModel>(reqDepartmentDto));
                var result = _mapper.Map<DepartmentModel>(reqDepartmentDto);
                if (result == null)
                    throw new Exception("Error occurred while saving the data");
                await _context.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<DepartmentModel>(result);
                return serviceResponse;
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message.ToString();
                return serviceResponse;
            }
        }

        async Task<ServiceResponse<DepartmentModel>> IDepartmentService.UpdateDepartmentDetails(int DeptId, ReqDepartmentDto requestDeptDetails)
        {
            var serviceResponse = new Models.ServiceResponse<DepartmentModel>();
            try
            {
                if (!DepartmentModelExists(DeptId))
                {
                    throw new Exception($"Department ID '{DeptId}' not found");
                }

                var result = await _context.DepartmentModels.FirstOrDefaultAsync(x => x.Id == DeptId);
                if (result == null)
                    throw new Exception($"Department ID '{DeptId}' not found");
                result.DepartmentName = requestDeptDetails.DepartmentName;
                serviceResponse.Data = _mapper.Map<DepartmentModel>(result);
                await _context.SaveChangesAsync();
                return serviceResponse;
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message.ToString();
                return serviceResponse;
            }
        }

        async Task<ServiceResponse<DepartmentModel>> IDepartmentService.DeleteDepartmentDetails(int DeptId)
        {
            var serviceResponse = new Models.ServiceResponse<DepartmentModel>();
            try
            {
                var departmentModel = await _context.DepartmentModels.FindAsync(DeptId);
                if (departmentModel != null)
                {
                    _context.DepartmentModels.Remove(departmentModel);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = departmentModel;
                    return serviceResponse;
                }
                else
                    throw new Exception($"Department ID '{DeptId}' not found");
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message.ToString();
                return serviceResponse;
            }
        }

        private bool DepartmentModelExists(int id)
        {
            return (_context.DepartmentModels?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
