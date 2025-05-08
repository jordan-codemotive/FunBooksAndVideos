using Ardalis.Result;
using Microsoft.Extensions.Logging;
using Shawbrook.FunBooksAndVideos.Application.Repositories;
using Shawbrook.FunBooksAndVideos.Domain.Models.Customer;
using Shawbrook.FunBooksAndVideos.Domain.Models.Enums;

namespace Shawbrook.FunBooksAndVideos.Infrastructure.Persistence.Repositories;

internal class CustomerRepository : ICustomerRepository
{
    private readonly IList<Customer> _customers = new List<Customer>();
    private readonly ILogger<CustomerRepository> _logger;

    public CustomerRepository(ILogger<CustomerRepository> logger)
    {
        _customers.Add(new Customer(1, "John", "Doe", 1, CustomerStatus.Inactive));
        _customers.Add(new Customer(2, "Sarah", "Doe", 1, CustomerStatus.Active));
        _logger = logger;
    }

    public Result ActivateCustomer(int customerId, int membershipId)
    {
        var customer = _customers.SingleOrDefault(x => x.Id == customerId);
        if (customer is null)
        {
            return Result.NotFound();
        }

        customer.Membership = membershipId;
        customer.Status = CustomerStatus.Active;

        _logger.LogInformation("Customer {customerId} activated with membership {membershipId}.", customerId, membershipId);

        return Result.Success();
    }

    public bool CheckCustomerExists(int id)
    {
        var customer = _customers.SingleOrDefault(x => x.Id == id);
        if (customer is null)
        {
            return false;
        }

        return true;
    }
}
