using CrmApi.Data.Abstract;
using CrmApi.Data.Concrete;
using CrmApi.Services.Abstract;
using CrmApi.Services.Concrete;
using CrmApi.Services;

namespace CrmApi.Extentions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddRepositories();
            services.AddBusinessServices();
            services.AddAuthServices();

            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }

        private static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }

        private static IServiceCollection AddAuthServices(this IServiceCollection services)
        {
            services.AddScoped<JwtService>();
            return services;
        }
    }
}
