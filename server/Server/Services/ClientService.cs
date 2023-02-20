using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Services
{
    public class ClientService
    {
        private readonly ClientRepository clientRepository;

        public ClientService(ClientRepository clientRepository)
        {
            this.clientRepository = clientRepository;
        }

        public async Task<List<Client>> GetAllClientsAsync()
        {
            return await clientRepository.GetAllClientsAsync();
        }
    }
}
