using CrmApi.Models;

namespace CrmApi.Services.Abstract
{
    public interface ICustomerService : IGenericService<Customer>
    {
        Task<IEnumerable<Customer>> SearchCustomersAsync(string searchTerm);
        Task<IEnumerable<Customer>> GetCustomersByCompanyAsync(string companyName);
    }
}
