using System;
using System.Collections.Generic;
using System.Text;

namespace ApiFerid.Business.Dtos.TokenDtos
{
  public class AccessTokenDto
    {
        public string Token { get; set; } = string.Empty;
        public DateTime ExpiredDate { get; set; }
    }
}
