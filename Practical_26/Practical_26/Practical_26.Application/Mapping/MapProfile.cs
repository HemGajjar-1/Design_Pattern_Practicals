using AutoMapper;
using Practical_26.Application.Commands;
using Practical_26.Application.Queries;
using Practical_26.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_26.Application.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<CreateEmployeeCommand, Employee>();
            CreateMap<UpdateEmployeeCommand, Employee>();
            CreateMap<Employee, EmployeeQueryDto>();
        }
    }
}
