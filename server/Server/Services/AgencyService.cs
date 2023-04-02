using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Services
{
    public class AgencyService
    {
        private readonly AgencyRepository agencyRepository;

        public AgencyService(AgencyRepository agencyRepository)
        {
            this.agencyRepository = agencyRepository;
        }

        public async Task<List<Agency>> GetAllAgenciesAsync()
        {
            return await agencyRepository.GetAllAgenciesAsync();
        }

        public async Task<Agency> AddAgencyAsync(Agency agency)
        {
            await agencyRepository.AddAgency(agency);
            return agency;
        }
    }
}
