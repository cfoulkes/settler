using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Repositories
{
    public class ClientRepository
    {
        private readonly DataContext context;

        public ClientRepository(DataContext context)
        {
            this.context = context;
        }

        public async Task<List<Client>> GetAllClientsAsync()
        {
            return await context.Clients.ToListAsync();
        }
    }
}
