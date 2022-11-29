using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SplitVeryWise.Application.Contracts.DTOs.User;
using SplitVeryWise.Domain.Entities;

namespace SplitVeryWise.Infrastructure.Profiles
{
    internal class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserResponse>();
            CreateMap<UserRegisterRequest, User>();
            CreateMap<UserLoginRequest, User>();
        }
    }
}
