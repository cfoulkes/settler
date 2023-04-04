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
            // model => dto
            CreateMap<User, UserDto>();
            CreateMap<UserProfile, UserProfileDto>();

            CreateMap<Client, ClientSearchDto>();
            CreateMap<Agency, AgencyDto>();

            CreateMap<ReferenceBase, LookupDto>();

            // dto => model
            CreateMap<AgencyDto, Agency>();
        }
    }
}
