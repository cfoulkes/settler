using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Repositories
{
    public class UserProfileRepository
    {
        private readonly DataContext context;

        public UserProfileRepository(DataContext context)
        {
            this.context = context;
        }

        public async Task<UserProfile?> GetUserProfileAsync(int id)
        {
            return await context.UserProfiles.FindAsync(id);
        }
    }
}
