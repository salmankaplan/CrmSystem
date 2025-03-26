using CrmApi.Data.Abstract;
using CrmApi.Models;
using CrmApi.Services.Abstract;

namespace CrmApi.Services.Concrete
{
    public class CustomerService : GenericService<Customer>, ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(
            ICustomerRepository customerRepository,
            ILogger<CustomerService> logger)
            : base(customerRepository, logger)
        {
            _customerRepository = customerRepository;
        }

        public async Task<IEnumerable<Customer>> SearchCustomersAsync(string searchTerm)
        {
            try
            {
                return await _customerRepository.FindAsync(c =>
                    c.FirstName.Contains(searchTerm) ||
                    c.LastName.Contains(searchTerm) ||
                    c.Email.Contains(searchTerm) ||
                    c.Company.Contains(searchTerm));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in {nameof(SearchCustomersAsync)} with term: {searchTerm}");
                throw;
            }
        }

        public async Task<IEnumerable<Customer>> GetCustomersByCompanyAsync(string companyName)
        {
            try
            {
                return await _customerRepository.SearchByCompanyAsync(companyName);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in {nameof(GetCustomersByCompanyAsync)} with company: {companyName}");
                throw;
            }
        }
    }
}
