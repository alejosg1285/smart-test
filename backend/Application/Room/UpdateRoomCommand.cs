using AutoMapper;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application;

public class UpdateRoomCommand
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

            var room = await _context.Rooms.FindAsync(request!.Room!.Id);
            if (room == null) return null;

            _mapper.Map(request.Room, room);
            
            var result = await _context.SaveChangesAsync() > 0;

            if (!result) return Result<Unit>.Failure("Failed to create the hotel");

            return Result<Unit>.Success(Unit.Value);
        }
    }
}
