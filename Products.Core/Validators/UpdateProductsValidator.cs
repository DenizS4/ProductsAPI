using FluentValidation;
using Products.Core.DTO;

namespace Products.Core.Validators;

public class UpdateProductsValidator : AbstractValidator<UpdateProductDto>
{
    public UpdateProductsValidator()
    {
        RuleFor(x=> x.ProductID).NotNull().WithMessage("Product ID cannot be null").NotEqual(0).WithMessage("Product ID cannot be 0");
        RuleFor(x=> x.ProductName).NotEmpty().WithMessage("Product Name cannot be empty").MaximumLength(150).WithMessage("Product Name cannot be more than 150 characters");
        RuleFor(x=> x.Category).NotNull().WithMessage("Category cannot be null").IsInEnum().WithMessage("Category must be a valid category");
        RuleFor(x=> x.UnitPrice).NotNull().WithMessage("Unit Price cannot be null").GreaterThan(0).WithMessage("Unit Price must be greater than 0");
        RuleFor(x=> x.Stock).NotNull().WithMessage("Stock cannot be null").GreaterThan(0).WithMessage("Stock must be greater than 0");
    }
}