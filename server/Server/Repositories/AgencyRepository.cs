using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Repositories
{
    public class AgencyRepository
    {
        private readonly DataContext context;

        public AgencyRepository(DataContext context)
        {
            this.context = context;
        }

        public async Task<List<Agency>> GetAllAgenciesAsync()
        {
            return await context.Agencies.ToListAsync();
        }
    }
}
