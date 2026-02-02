using ApiFerid.Business.Dtos.ResultsDto;
using ApiFerid.Business.Dtos.TokenDtos;
using ApiFerid.Business.Dtos.UserDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiFerid.Business.Services.Abstractions
{
 public interface IAuthService
    {
        Task<ResultDto> RegisterAsync(RegisterDto dto);
        Task<ResultDto<AccessTokenDto>> LoginAsync(LoginDto dto);
    }
}
