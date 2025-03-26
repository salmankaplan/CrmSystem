using CrmApi.Data.Abstract;
using CrmApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CrmApi.Data.Concrete
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            try
            {
                if(string.IsNullOrEmpty(username))
                {
                    return new User();
                }

                return await _dbSet.FirstOrDefaultAsync(u => u.Username == username);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
