using ApiFerid.Business.Dtos.EmployeeDtos;
using ApiFerid.Business.Dtos.ResultsDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiFerid.Business.Services.Abstractions
{
    public interface IEmployeeService
    {
        Task<ResultDto> CreateAsync(EmployeeCreateDto dto);
        Task<ResultDto> DeleteAsync(Guid id);
        Task<ResultDto<List<EmployeeGetDto>>> GetAllAsync();
        Task<ResultDto> UpdateAsync(EmployeeUpdateDto dto);
        Task<ResultDto<EmployeeGetDto>> GetByIdAsync(Guid id);
    }
}
