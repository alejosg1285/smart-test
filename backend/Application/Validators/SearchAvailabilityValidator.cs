using FluentValidation;

namespace Application;

public class SearchAvailabilityValidator : AbstractValidator<SearchAvailabilityRequest>
{
    public SearchAvailabilityValidator()
    {
        RuleFor(x => x.StartSearch).NotEmpty().Must(startSearch => !startSearch.Equals(default(DateTime)));
        RuleFor(x => x.EndSearch).NotEmpty().Must(endSearch => !endSearch.Equals(default(DateTime)));
        RuleFor(v => v.City).NotEmpty();
        RuleFor(x => x.Capacity).NotEmpty().NotNull();
    }
}
