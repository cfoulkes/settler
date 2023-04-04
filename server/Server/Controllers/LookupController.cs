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
    public class LookupController : ControllerBase
    {
        private readonly LookupService lookupService;
        private readonly IMapper mapper;

        public LookupController(LookupService lookupService, IMapper mapper)
        {
            this.lookupService = lookupService;
            this.mapper = mapper;
        }

        [HttpGet("{lookup}/{language}")]
        [Authorize]
        public async Task<ActionResult<List<LookupDto>>> GetLookups(string lookup, string language)
        {
            try
            {
                var lookups = await lookupService.GetLookupsAsync(lookup, language);
                return Ok(mapper.Map<List<ReferenceBase>, List<LookupDto>>(lookups));
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
