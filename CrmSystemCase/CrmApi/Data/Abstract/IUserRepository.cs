using CrmApi.Models;

namespace CrmApi.Data.Abstract
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetUserByUsernameAsync(string username);
    }
}
