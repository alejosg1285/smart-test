using Domain;
using FluentValidation;

namespace Application;

public class HotelValidator : AbstractValidator<Hotel>
{
    public HotelValidator()
    {
        RuleFor(v => v.Address).NotEmpty();
        RuleFor(v => v.City).NotEmpty();
        RuleFor(v => v.Description).NotEmpty();
        RuleFor(v => v.Name).NotEmpty();
    }
}
