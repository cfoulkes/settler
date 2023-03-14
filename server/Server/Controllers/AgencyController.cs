using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Server.Dtos;

namespace Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AgencyController : ControllerBase
    {
        private readonly AgencyService agencyService;
        private readonly IMapper mapper;

        public AgencyController(AgencyService agencyService, IMapper mapper)
        {
            this.mapper = mapper;
            this.agencyService = agencyService;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<AgencyDto>>> GetAllAgencies()
        {
            try
            {
                var agencies = await agencyService.GetAllAgenciesAsync();
                return Ok(mapper.Map<List<Agency>, List<AgencyDto>>(agencies));
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
