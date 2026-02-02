using ApiFerid.Business.Dtos.UserDtos;
using ApiFerid.Core.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiFerid.Business.Profiles
{
    internal class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<AppUser, RegisterDto>().ReverseMap();
        }
    }
}
