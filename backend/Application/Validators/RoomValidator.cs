using Domain;
using FluentValidation;

namespace Application;

public class RoomValidator : AbstractValidator<RoomRequest>
{
    public RoomValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
        RuleFor(x => x.Capacity).NotEmpty().NotNull();
        RuleFor(x => x.TypeRoom).NotEmpty();
        RuleFor(x => x.Price).NotEmpty().NotNull();
        RuleFor(x => x.Taxes).NotEmpty().NotNull();
        RuleFor(x => x.Location).NotEmpty();
        RuleFor(x => x.HotelId).NotEmpty().NotNull();
    }
}
