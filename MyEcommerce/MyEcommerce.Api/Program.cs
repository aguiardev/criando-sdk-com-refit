using Microsoft.EntityFrameworkCore;
using MyEcommerce.Api.Models;
using MyEcommerce.Api.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MyEcommerceContext>(opt =>
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/customer", async (ICustomerRepository customerRepository) =>
{
    try
    {
        var customers = await customerRepository.GetAllAsync();

        return customers is null || !customers.Any()
            ? Results.NotFound() : Results.Ok(customers);
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex.Message);
    }
})
.Produces<Customer[]>(StatusCodes.Status200OK)
.Produces(StatusCodes.Status404NotFound)
.WithName("GetCustomer")
.WithTags("Customer");

app.MapGet("/customer/{id}", async (ICustomerRepository customerRepository, int id) =>
{
    try
    {
        var customer = await customerRepository.GetByIdAsync(id);

        return customer is null ? Results.NotFound() : Results.Ok(customer);
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex.Message);
    }
})
.Produces<Customer>(StatusCodes.Status200OK)
.Produces(StatusCodes.Status404NotFound)
.WithName("GetCustomerById")
.WithTags("Customer");

app.MapPost("/customer", async (ICustomerRepository customerRepository, Customer customer) =>
{
    try
    {
        await customerRepository.CreateAsync(customer);

        return Results.CreatedAtRoute("GetCustomerById", new { id = customer.Id }, customer);
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex.Message);
    }
})
.Produces<Customer>(StatusCodes.Status201Created)
.Produces(StatusCodes.Status400BadRequest)
.WithName("PostCustomer")
.WithTags("Customer");

app.MapPut("/customer/{id}", async (ICustomerRepository customerRepository, int id, Customer customer) =>
{
    try
    {
        await customerRepository.UpdateAsync(id, customer);

        return Results.NoContent();
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex.Message);
    }
})
.Produces<Customer>(StatusCodes.Status201Created)
.Produces(StatusCodes.Status400BadRequest)
.WithName("PutCustomer")
.WithTags("Customer");

app.MapDelete("/customer/{id}", async (ICustomerRepository customerRepository, int id) =>
{
    try
    {
        await customerRepository.DeleteAsync(id);

        return Results.NoContent();
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex.Message);
    }
})
.Produces<Customer>(StatusCodes.Status200OK)
.Produces(StatusCodes.Status404NotFound)
.WithName("DeleteCustomerById")
.WithTags("Customer");

app.Run();