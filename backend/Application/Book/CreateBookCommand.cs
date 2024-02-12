using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application;

public class CreateBookCommand
{
    public class Command : IRequest<Result<Unit>>
    {
        public BookRequest? Book { get; set; }
    }

    public class Handler : IRequestHandler<Command, Result<Unit>>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IValidator<BookRequest> _validator;
        private readonly IEmailService _emailService;

        public Handler(DataContext context, IMapper mapper, IValidator<BookRequest> validator, IEmailService emailService)
        {
            _validator = validator;
            _emailService = emailService;
            _mapper = mapper;
            _context = context;
        }

        public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request.Book!);

            var book = new Book();
            _mapper.Map(request!.Book, book);
            _context.Books.Add(book);
            var result = await _context.SaveChangesAsync() > 0;

            if (!result) return Result<Unit>.Failure("Failed to create the book");

            var bookedEmail = "Reserva realizada con exito en el hotel  del " + string.Format("{0:yyyy-MM-dd}", book.StartBook) + " al " + string.Format("{0:yyyy-MM-dd}", book.EndBook);

            EmailMetadata emailMetadata = new(book.Passengers.First().Email!, "Reserva realizada", bookedEmail);
            await _emailService.Send(emailMetadata);
            return Result<Unit>.Success(Unit.Value);
        }
    }
}
