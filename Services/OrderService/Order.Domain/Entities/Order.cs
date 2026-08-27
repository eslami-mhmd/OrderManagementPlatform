using Order.Domain.Exceptions;

namespace Order.Domain.Entities;

public sealed class Order
{
    private Order()
    {
    }


    private Order(
        Guid id,
        Guid customerId)
    {
        Id = id;
        CustomerId = customerId;
        CreatedAt = DateTime.UtcNow;
    }


    public Guid Id { get; private set; }


    public Guid CustomerId { get; private set; }


    public DateTime CreatedAt { get; private set; }



    public static Order Create(
        Guid customerId)
    {
        if (customerId == Guid.Empty)
        {
            throw new DomainException(
                "Customer id is required.");
        }


        return new Order(
            Guid.NewGuid(),
            customerId);
    }
}