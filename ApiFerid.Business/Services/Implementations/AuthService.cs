using ApiFerid.Business.Dtos.ResultsDto;
using ApiFerid.Business.Dtos.TokenDtos;
using ApiFerid.Business.Dtos.UserDtos;
using ApiFerid.Business.Exceptions;
using ApiFerid.Business.Services.Abstractions;
using ApiFerid.Core.Entities;
using ApiFerid.Core.Enums;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace ApiFerid.Business.Services.Implementations
{
    internal class AuthService(UserManager<AppUser> _userManager, IMapper _mapper, IJWTService _jwtService) : IAuthService
    {
        public async Task<ResultDto<AccessTokenDto>> LoginAsync(LoginDto dto)
        {

            var user = await _userManager.FindByNameAsync(dto.EmailOrUsername);


            if (user is null)
            {
                user = await _userManager.FindByEmailAsync(dto.EmailOrUsername);

                if (user is null)
                    throw new LoginException();
            }

            var isTruePassword = await _userManager.CheckPasswordAsync(user, dto.Password);


            if (!isTruePassword)
                throw new LoginException();

            var roles = await _userManager.GetRolesAsync(user);


            List<Claim> claims = new()
        {
            new Claim("Username",user.UserName!),
            new Claim("Email",user.Email!),
            new Claim("Fullname",user.Fullname!),
            new Claim("Role",roles.FirstOrDefault() ?? "undefiend"),
        };

            var tokenResult = _jwtService.CreateAccessToken(claims);


            return new(tokenResult);

        }

        public async Task<ResultDto> RegisterAsync(RegisterDto dto)
        {
            var isExistEmail = await _userManager.Users.AnyAsync(x => x.Email!.ToLower() == dto.Email.ToLower());
            if (isExistEmail)
                throw new AlreadyExistException("This email is already exist");

            var isExistUserName = await _userManager.Users.AnyAsync(x => x.UserName!.ToLower() == dto.UserName.ToLower());

            if (isExistUserName)
                throw new AlreadyExistException("This username is already exist");

            var appUser = _mapper.Map<AppUser>(dto);

            var result = await _userManager.CreateAsync(appUser, dto.Password);

            if (!result.Succeeded)
            {
                string message = string.Join(",\n", result.Errors.Select(x => x.Description));

                throw new RegisterException(message);
            }

            await _userManager.AddToRoleAsync(appUser, IdentityRoles.Member.ToString());

            return new();

        }
    }
}
