using FluentValidation;
using Products.Core.DTO;

namespace Products.Core.Validators;

public class AddProductsValidator : AbstractValidator<AddProductDto>
{
    public AddProductsValidator()
    {
        RuleFor(x => x.ProductName).NotEmpty().WithMessage("Product name cannot be empty").MaximumLength(150).WithMessage("Product name cannot exceed 150 characters");
        RuleFor(x => x.Category).NotNull().WithMessage("Product category cannot be null").IsInEnum().WithMessage("Product category must be a valid category");
        RuleFor(x => x.UnitPrice).NotNull().WithMessage("Unit price cannot be null").GreaterThan(0).WithMessage("Unit price must be greater than 0");
        RuleFor(x => x.Stock).NotNull().WithMessage("Stock cannot be null").GreaterThan(0).WithMessage("Stock must be greater than 0");
    }
}