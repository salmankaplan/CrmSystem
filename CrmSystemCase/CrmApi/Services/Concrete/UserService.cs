using CrmApi.Data.Abstract;
using CrmApi.Models;
using CrmApi.Services.Abstract;

namespace CrmApi.Services.Concrete
{
    public class UserService : GenericService<User>, IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(
            IUserRepository userRepository,
            ILogger<UserService> logger)
            : base(userRepository, logger)
        {
            _userRepository = userRepository;
        }

        public async Task<User> GetUserByNameAsync(string userName)
        {
            try
            {
                if(string.IsNullOrEmpty(userName))
                    return new User();

                var user = await _userRepository.GetUserByUsernameAsync(userName);
                return user;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in {nameof(GetUserByNameAsync)} with userName: {userName}");
                throw;
            }
        }

        public async Task<bool> CheckUserAsync(string userName, string password)
        {
            try
            {
                var user = await _userRepository.GetUserByUsernameAsync(userName);

                if (user == null)
                    return false;

                return user.Password == password;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in {nameof(CheckUserAsync)} with userName: {userName}");
                throw;
            }
        }
    }
}
