using MyEcommerce.Api.Models;

namespace MyEcommerce.Api.Repositories;

public interface ICustomerRepository
{
    Task<IList<Customer>> GetAllAsync();
    Task<Customer?> GetByIdAsync(int id);
    Task CreateAsync(Customer customer);
    Task UpdateAsync(int id, Customer customer);
    Task DeleteAsync(int id);
}