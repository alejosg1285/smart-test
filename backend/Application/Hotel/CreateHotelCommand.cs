using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application;

public class CreateHotelCommand
{
    public class Command : IRequest<Result<Unit>>
    {
        public Hotel? Hotel { get; set; }
    }

    public class Handler : IRequestHandler<Command, Result<Unit>>
    {
        private readonly DataContext _context;
        private readonly IValidator<Hotel> _validator;

        public Handler(DataContext context, IValidator<Hotel> validator)
        {
            _validator = validator;
            _context = context;
        }

        public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request.Hotel!);

            request.Hotel!.IsActive = true;
            _context.Hotels.Add(request.Hotel!);
            var result = await _context.SaveChangesAsync() > 0;

            if (!result) return Result<Unit>.Failure("Failed to create the hotel");

            return Result<Unit>.Success(Unit.Value);
        }
    }
}
