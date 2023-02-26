using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Services
{
    public class UserProfileService
    {
        private readonly UserProfileRepository userProfileRepository;

        public UserProfileService(UserProfileRepository userProfileRepository)
        {
            this.userProfileRepository = userProfileRepository;
        }

        public async Task<UserProfile?> GetUserProfileAsync(int id)
        {
            return await userProfileRepository.GetUserProfileAsync(id);
        }
    }
}
