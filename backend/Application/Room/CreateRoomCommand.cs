using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application;

public class CreateRoomCommand
{
    public class Command : IRequest<Result<Unit>>
    {
        public RoomRequest? Room { get; set; }
    }

    public class Handler : IRequestHandler<Command, Result<Unit>>
    {
        private readonly DataContext _context;
        private readonly IValidator<RoomRequest> _validator;
        private readonly IMapper _mapper;
        
        public Handler(DataContext context, IValidator<RoomRequest> validator, IMapper mapper)
        {
            _validator = validator;
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request.Room!);

            request.Room!.IsActive = true;
            var room = new Room();

            _mapper.Map(request.Room, room);
            _context.Rooms.Add(room);
            var result = await _context.SaveChangesAsync() > 0;

            if (!result) return Result<Unit>.Failure("Failed to create the hotel");

            return Result<Unit>.Success(Unit.Value);
        }
    }
}
