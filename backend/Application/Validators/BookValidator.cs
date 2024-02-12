using Domain;
using FluentValidation;

namespace Application;

public class BookValidator : AbstractValidator<BookRequest>
{
    public BookValidator()
    {
        RuleFor(x => x.StartBook).NotEmpty().Must(startBook => !startBook.Equals(default(DateTime)));
        RuleFor(x => x.EndBook).NotEmpty().Must(endBook => !endBook.Equals(default(DateTime)));

        RuleForEach(x => x.Passengers).ChildRules(passenger =>
        {
            passenger.RuleFor(p => p.Name).NotEmpty();
            passenger.RuleFor(p => p.LastName).NotEmpty();
            passenger.RuleFor(p => p.IdentificationType).NotEmpty();
            passenger.RuleFor(p => p.IdentificationNumber).NotEmpty();
            passenger.RuleFor(p => p.Genre).NotEmpty().IsInEnum();
            passenger.RuleFor(p => p.Email).NotEmpty().EmailAddress();
            passenger.RuleFor(p => p.PhoneNumber).Length(10).NotEmpty();
        });

        RuleFor(x => x.RoomId).NotEmpty();
        RuleFor(x => x.Contact!.Name).NotEmpty();
        RuleFor(x => x.Contact!.LastName).NotEmpty();
        RuleFor(x => x.Contact!.PhoneNumber).Length(10).NotEmpty();
    }

    /* private bool BeValidateDate(DateTime date)
    {
        return !date.Equals(default(DateTime));
    } */
}
