using ApiFerid.Core.Entities;
using ApiFerid.DataAccess.Repositories.Abstractions.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiFerid.DataAccess.Repositories.Abstractions
{
    public interface IEmployeeRepository:IRepository<Employee>
    {
    }
}
