using System;
using System.Collections.Generic;
using System.Text;

namespace ApiFerid.Business.Exceptions
{
    public class AlreadyExistException(string message = "This item is already exist") : Exception(message)
    {

    }
}
