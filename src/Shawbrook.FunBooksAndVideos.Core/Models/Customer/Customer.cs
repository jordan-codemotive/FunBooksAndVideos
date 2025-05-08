using Shawbrook.FunBooksAndVideos.Domain.Models.Enums;

namespace Shawbrook.FunBooksAndVideos.Domain.Models.Customer;

public class Customer(int id, string firstName, string lastName, int membership, CustomerStatus status)
{
    public int Id { get; set; } = id;
    public string FirstName { get; set; } = firstName;
    public string LastName { get; set; } = lastName;
    public int Membership { get; set; } = membership;
    public CustomerStatus Status { get; set; } = status;
}
