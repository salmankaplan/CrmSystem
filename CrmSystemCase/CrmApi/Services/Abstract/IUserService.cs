using CrmApi.Models;

namespace CrmApi.Services.Abstract
{
    public interface IUserService : IGenericService<User>
    {
        Task<User> GetUserByNameAsync(string userName);
        Task<bool> CheckUserAsync(string userName, string password);
    }
}
