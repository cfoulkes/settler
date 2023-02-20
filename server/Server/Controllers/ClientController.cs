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
    public class ClientController : ControllerBase
    {
        private readonly ClientService clientService;
        private readonly IMapper mapper;

        public ClientController(ClientService clientService, IMapper mapper)
        {
            this.clientService = clientService;
            this.mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<ClientSearchDto>>> GetAllClients()
        {
            try
            {
                var clients = await clientService.GetAllClientsAsync();
                return Ok(mapper.Map<List<Client>, List<ClientSearchDto>>(clients));
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
