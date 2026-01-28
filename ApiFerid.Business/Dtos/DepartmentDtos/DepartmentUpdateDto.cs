using ApiFerid.Business.Dtos.EmployeeDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiFerid.Business.Dtos.DepartmentDtos
{
 public class DepartmentUpdateDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<EmployeeGetDto> Employees { get; set; } = [];
    }
}
