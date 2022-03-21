using AutoMapper;

namespace ReportsBLL.Tools.Mapping
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeDto>();

            ShouldUseConstructor = info => info.IsFamily || info.IsPublic;
            CreateMap<AddEmployeeDto, Employee>();
            CreateMap<UpdateEmployeeDto, Employee>();
        }
    }
}