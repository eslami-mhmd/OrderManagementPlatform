namespace Contracts;

public sealed record CustomerCreatedMessage(
    Guid CustomerId,
    string Name,
    string Email);