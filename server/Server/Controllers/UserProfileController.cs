using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Server.Dtos;

namespace Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserProfileController : ControllerBase
    {
        private readonly UserProfileService userProfileService;
        private readonly IMapper mapper;

        public UserProfileController(UserProfileService userProfileService, IMapper mapper)
        {
            this.mapper = mapper;
            this.userProfileService = userProfileService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserProfileDto>> GetUserProfileAsync(int id)
        {
            var UserProfile = await userProfileService.GetUserProfileAsync(id);
            var UserProfileDto = mapper.Map<UserProfile, UserProfileDto>(UserProfile);
            return Ok(UserProfileDto);
        }
    }
}
