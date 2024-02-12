using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application;

public class GetAvailabilityQuery
{
    public class Query : IRequest<Result<List<HotelDto>>>
    {
        public SearchAvailabilityRequest? search { get; set; }
    }

    public class Handler : IRequestHandler<Query, Result<List<HotelDto>>>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IValidator<SearchAvailabilityRequest> _validator;

        public Handler(DataContext context, IMapper mapper, IValidator<SearchAvailabilityRequest> validator)
        {
            _context = context;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<Result<List<HotelDto>>> Handle(Query request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request.search!);

            var query = _context.Books
                .Where(b => b.EndBook <= request!.search!.StartSearch || b.EndBook >= request!.search!.EndSearch)
                .Where(b => b.StartBook <= request!.search!.StartSearch || b.StartBook >= request!.search!.EndSearch)
                .Where(b => b.Room.Capacity <= request!.search!.Capacity)
                .Where(b => b.Room.IsActive)
                .Where(b => b.Room!.Hotel!.City!.ToLower().Contains(request!.search!.City!.ToLower()))
                .Select(b => b.Room!.Hotel)
                .Distinct()
                .ProjectTo<HotelDto>(_mapper.ConfigurationProvider)
                .AsQueryable();
            
            return Result<List<HotelDto>>.Success(await query.ToListAsync(cancellationToken));
        }
    }
}
