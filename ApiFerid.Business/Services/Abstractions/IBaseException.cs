using System;
using System.Collections.Generic;
using System.Text;

namespace ApiFerid.Business.Services.Abstractions
{
    public interface IBaseException
    {
        public int StatusCode { get; set; }
    }
}
