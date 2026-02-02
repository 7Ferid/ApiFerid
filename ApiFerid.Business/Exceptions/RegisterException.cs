using ApiFerid.Business.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiFerid.Business.Exceptions
{
    public class RegisterException(string message = "Registration failed") : Exception(message), IBaseException
    {
        public int StatusCode { get; set; } = 400;
    }
}
