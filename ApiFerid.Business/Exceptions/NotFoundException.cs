using ApiFerid.Business.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiFerid.Business.Exceptions
{
    public class NotFoundException(string message = "Object is not found") : Exception(message), IBaseException
    {
        public int StatusCode { get; set; } = 404;
    }
}
