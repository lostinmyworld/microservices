using Api.Data.Access.DataTypes.DTOs;
using Api.Data.EfCore.Database;
using AutoMapper;

namespace Api.Data.Access.Services.Helpers
{
    public class DataAccessMapping : Profile
    {
        public DataAccessMapping()
        {
            CreateMap<EmployeeDTO, Employee>().ReverseMap();
        }
    }
}
