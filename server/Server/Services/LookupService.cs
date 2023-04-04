using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Services
{
    public class LookupService
    {
        private readonly DataContext context;

        public LookupService(DataContext context)
        {
            this.context = context;
        }

        public async Task<List<ReferenceBase>> GetLookupsAsync(string table, string language)
        {
            List<ReferenceBase> lookups = new List<ReferenceBase>();
            switch (table)
            {
                case "AgencyStatus":
                    lookups = (await this.context.AgencyStatuses.ToListAsync()).ConvertAll(
                        x => (ReferenceBase)x
                    );
                    break;
                default:
                    break;
            }

            return lookups;
        }
    }
}
