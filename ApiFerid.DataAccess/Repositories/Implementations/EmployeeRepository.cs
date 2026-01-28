using ApiFerid.Core.Entities;
using ApiFerid.DataAccess.Context;
using ApiFerid.DataAccess.Repositories.Abstractions;
using ApiFerid.DataAccess.Repositories.Implementations.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiFerid.DataAccess.Repositories.Implementations
{
    internal class EmployeeRepository(AppDbContext _context) : Repository<Employee>(_context), IEmployeeRepository
    {
    }
}
