using Application.DTOs;
using FluentValidation;

namespace Application.Validators;

public class CreateProductRequestValidator : AbstractValidator<CreateProductRequest>
{
    public CreateProductRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name cannot be empty.")
            .MaximumLength(200);

        RuleFor(x => x.BasePrice)
            .GreaterThan(0);

        RuleFor(x => x.CategoryId)
            .NotEmpty();
    }
}