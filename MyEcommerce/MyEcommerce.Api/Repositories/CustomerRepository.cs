using Microsoft.EntityFrameworkCore;
using MyEcommerce.Api.Models;

namespace MyEcommerce.Api.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly MyEcommerceContext _myEcommerceContext;

    public CustomerRepository(MyEcommerceContext myEcommerceContext)
        => _myEcommerceContext = myEcommerceContext;

    public async Task DeleteAsync(int id)
    {
        var customer = await GetByIdAsync(id);

        _myEcommerceContext.Customers.Remove(customer);
        await _myEcommerceContext.SaveChangesAsync();
    }

    public async Task<IList<Customer>> GetAllAsync()
        => await _myEcommerceContext.Customers.ToListAsync();

    public async Task<Customer?> GetByIdAsync(int id)
        => await _myEcommerceContext.Customers.FirstOrDefaultAsync(f => f.Id == id);

    public async Task CreateAsync(Customer customer)
    {
        _myEcommerceContext.Customers.Add(customer);
        await _myEcommerceContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(int id, Customer customer)
    {
        var currentCustomer = await GetByIdAsync(id);

        if (currentCustomer is null)
            return;

        currentCustomer.Name = customer.Name;
        currentCustomer.Email = customer.Email;
        currentCustomer.Birth = customer.Birth;

        await _myEcommerceContext.SaveChangesAsync();
    }
}