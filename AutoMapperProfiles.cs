namespace EmployeeManagementSystem
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<DepartmentModel, ReqDepartmentDto>().ReverseMap();
            CreateMap<DepartmentModel, RespDepartmentDto>().ReverseMap();

            CreateMap<EmployeeModel, ReqEmployeeDto>().ReverseMap();
            CreateMap<EmployeeModel, RespEmployeeDto>().ReverseMap();

        }


    }
}
