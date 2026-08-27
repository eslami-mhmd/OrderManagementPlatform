using FluentValidation;

namespace Customer.Application.Customers.CreateCustomer;

public sealed class CreateCustomerCommandValidator
    : AbstractValidator<CreateCustomerCommand>
{
    public CreateCustomerCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(100);


        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();
    }
}