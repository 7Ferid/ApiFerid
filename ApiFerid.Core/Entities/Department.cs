using ApiFerid.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiFerid.Core.Entities
{
   public class Department:BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public List<Employee> Employees { get; set; } = [];
    }
}
