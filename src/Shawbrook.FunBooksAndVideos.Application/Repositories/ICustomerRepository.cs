using Ardalis.Result;

namespace Shawbrook.FunBooksAndVideos.Application.Repositories;

public interface ICustomerRepository
{
    public bool CheckCustomerExists(int id);
    public Result ActivateCustomer(int customerId, int membershipId);
}
