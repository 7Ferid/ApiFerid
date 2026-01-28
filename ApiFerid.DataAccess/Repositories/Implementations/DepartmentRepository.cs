using ApiFerid.Core.Entities;
using ApiFerid.DataAccess.Context;
using ApiFerid.DataAccess.Repositories.Abstractions;
using ApiFerid.DataAccess.Repositories.Implementations.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiFerid.DataAccess.Repositories.Implementations
{
    internal class DepartmentRepository(AppDbContext _context) : Repository<Department>(_context), IDepartmentRepository
    {
    }
}
