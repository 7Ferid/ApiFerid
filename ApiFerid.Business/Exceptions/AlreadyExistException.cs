using ApiFerid.Business.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiFerid.Business.Exceptions
{
    public class AlreadyExistException(string message = "This item is already exist") : Exception(message), IBaseException
    {
        public int StatusCode { get; set; } = 409;
    }
}
