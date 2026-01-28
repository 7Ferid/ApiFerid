using ApiFerid.Business.Dtos.DepartmentDtos;
using ApiFerid.Core.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiFerid.Business.Profiles
{
    internal class DepartmentProfile:Profile
    {
        public DepartmentProfile()
        {
            CreateMap<Department, DepartmentGetDto>().ReverseMap();
            CreateMap<Department, DepartmentCreateDto>().ReverseMap();
            CreateMap<Department, DepartmentUpdateDto>().ReverseMap();
        }
    }
}
