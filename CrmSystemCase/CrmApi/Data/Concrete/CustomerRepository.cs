using CrmApi.Data.Abstract;
using CrmApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CrmApi.Data.Concrete
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Customer>> SearchByCompanyAsync(string companyName)
        {
            return await _dbSet.Where(c => c.Company.Contains(companyName)).ToListAsync();
        }
    }
}
