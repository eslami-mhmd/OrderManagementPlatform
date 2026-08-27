using Customer.Domain.Exceptions;

namespace Customer.Domain.Entities;

public sealed class Customer
{
    private Customer()
    {
        // Required by EF Core
    }


    private Customer(
        Guid id,
        string name,
        string email)
    {
        Id = id;
        Name = name;
        Email = email;
    }


    public Guid Id { get; private set; }


    public string Name { get; private set; } = string.Empty;


    public string Email { get; private set; } = string.Empty;



    public static Customer Create(
        string name,
        string email)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new DomainException(
                "Customer name is required.");
        }


        if (string.IsNullOrWhiteSpace(email))
        {
            throw new DomainException(
                "Customer email is required.");
        }


        return new Customer(
            Guid.NewGuid(),
            name,
            email);
    }



    public void UpdateEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            throw new DomainException(
                "Customer email is required.");
        }


        Email = email;
    }
}