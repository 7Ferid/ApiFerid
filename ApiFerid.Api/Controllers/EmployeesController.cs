using ApiFerid.Business.Dtos.EmployeeDtos;
using ApiFerid.Business.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace ApiFerid.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController(IEmployeeService _service) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var employees = await _service.GetAllAsync();
            return Ok(employees);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var product = await _service.GetByIdAsync(id);
            return Ok(product);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] EmployeeCreateDto dto)
        {
            await _service.CreateAsync(dto);
            return Ok();
        }


        [HttpPut]
        public async Task<IActionResult> Update([FromForm] EmployeeUpdateDto dto)
        {
            await _service.UpdateAsync(dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }

    }
}
