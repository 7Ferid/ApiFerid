using ApiFerid.Business.Dtos.DepartmentDtos;
using ApiFerid.Business.Dtos.ResultsDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiFerid.Business.Services.Abstractions
{
    public interface IDepartmentService
    {
        Task<ResultDto> CreateAsync(DepartmentCreateDto dto);
        Task<ResultDto> UpdateAsync(DepartmentUpdateDto dto);
        Task<ResultDto> DeleteAsync(Guid id);
        Task<ResultDto<List<DepartmentGetDto>>> GetAllAsync();
        Task<ResultDto<DepartmentGetDto>> GetByIdAsync(Guid id);
    }
}
