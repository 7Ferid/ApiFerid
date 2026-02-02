using ApiFerid.Business.Dtos.TokenDtos;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace ApiFerid.Business.Services.Abstractions
{
    public interface IJWTService
    {
        AccessTokenDto CreateAccessToken(List<Claim> claims);
    }
}
