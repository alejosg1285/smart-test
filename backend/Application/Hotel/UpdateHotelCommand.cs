using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application;

public class UpdateHotelCommand
{
    public class Command : IRequest<Result<Unit>>
    {
        public Hotel? Hotel { get; set; }
    }

    public class Handler : IRequestHandler<Command, Result<Unit>>
    {
        private readonly DataContext _context;
        private readonly IValidator<Hotel> _validator;
        private readonly IMapper _mapper;

        public Handler(DataContext context, IValidator<Hotel> validator, IMapper mapper)
        {
            _validator = validator;
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request.Hotel!);

            var hotel = await _context.Hotels.FindAsync(request!.Hotel!.Id);
            if (hotel == null) return null;

            _mapper.Map(request.Hotel, hotel);
            
            var result = await _context.SaveChangesAsync() > 0;

            if (!result) return Result<Unit>.Failure("Failed to update the hotel");

            return Result<Unit>.Success(Unit.Value);
        }
    }
}
