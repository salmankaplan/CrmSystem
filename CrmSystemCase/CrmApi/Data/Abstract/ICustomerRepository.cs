using CrmApi.Models;

namespace CrmApi.Data.Abstract
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<IEnumerable<Customer>> SearchByCompanyAsync(string companyName);
    }
}
