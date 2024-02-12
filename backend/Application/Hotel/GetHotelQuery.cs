using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application;

public class GetHotelQuery
{
    public class Query : IRequest<Result<HotelDto>>
    {
        public int Id { get; set; }
    }

    public class Handler : IRequestHandler<Query, Result<HotelDto>>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public Handler(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Result<HotelDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var hotel = await _context.Hotels
                .ProjectTo<HotelDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(x => x.Id == request.Id);
            return Result<HotelDto>.Success(hotel!);
        }
    }
}
