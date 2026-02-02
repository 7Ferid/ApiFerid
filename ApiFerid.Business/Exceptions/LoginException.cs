using ApiFerid.Business.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiFerid.Business.Exceptions
{
  public class LoginException(string message = "Some Credeantials are wrong") : Exception(message), IBaseException
    {
        public int StatusCode { get; set; } = 400;
    }

}
