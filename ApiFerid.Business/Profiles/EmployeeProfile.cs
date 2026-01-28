using ApiFerid.Business.Dtos.EmployeeDtos;
using ApiFerid.Core.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiFerid.Business.Profiles
{
    internal class EmployeeProfile:Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeGetDto>().ReverseMap();
            CreateMap<Employee, EmployeeCreateDto>().ReverseMap();
            CreateMap<Employee, EmployeeUpdateDto>().ReverseMap();
        }
    }
}
