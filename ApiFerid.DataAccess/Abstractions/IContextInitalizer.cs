using System;
using System.Collections.Generic;
using System.Text;

namespace ApiFerid.DataAccess.Abstractions
{
   public interface IContextInitalizer
    {
        Task InitDatabaseAsync();
    }
}
