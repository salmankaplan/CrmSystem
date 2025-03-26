using CrmApi.Data.Abstract;
using CrmApi.Services.Abstract;
using System.Linq.Expressions;

namespace CrmApi.Services.Concrete
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        protected readonly IRepository<T> _repository;
        protected readonly ILogger<GenericService<T>> _logger;

        public GenericService(IRepository<T> repository, ILogger<GenericService<T>> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                return await _repository.GetAllAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in {nameof(GetAllAsync)}");
                throw;
            }
        }

        public async Task<T> GetByIdAsync(int id)
        {
            try
            {
                return await _repository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in {nameof(GetByIdAsync)} with id: {id}");
                throw;
            }
        }

        public async Task<T> CreateAsync(T entity)
        {
            try
            {
                return await _repository.AddAsync(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in {nameof(CreateAsync)}");
                throw;
            }
        }

        public async Task<T> UpdateAsync(T entity)
        {
            try
            {
                return await _repository.UpdateAsync(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in {nameof(UpdateAsync)}");
                throw;
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                await _repository.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in {nameof(DeleteAsync)} with id: {id}");
                throw;
            }
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            try
            {
                return await _repository.FindAsync(predicate);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in {nameof(FindAsync)}");
                throw;
            }
        }
    }
}
