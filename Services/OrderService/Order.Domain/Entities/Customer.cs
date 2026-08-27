namespace Order.Domain.Entities;

public sealed class Customer
{
    private Customer()
    {
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
        Guid id,
        string name,
        string email)
    {
        return new Customer(
            id,
            name,
            email);
    }
}