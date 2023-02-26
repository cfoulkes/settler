using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Server.Dtos;

namespace Server.Controllers.Utilities
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserProfile, UserProfileDto>();

            CreateMap<Client, ClientSearchDto>();
        }
    }
}
