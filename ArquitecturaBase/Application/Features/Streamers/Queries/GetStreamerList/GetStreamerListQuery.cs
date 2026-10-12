using Application.Features.Streamers.Queries.GetStreamerByName;
using AutoMapper;
using Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Streamers.Queries.GetStreamerList
{
    public record GetStreamerListQuery : IRequest<List<StreamersVM>> { };

    public class GetStreamersQueryHandler : IRequestHandler<GetStreamerListQuery, List<StreamersVM>>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _dbContext;


        public GetStreamersQueryHandler(IMapper mapper,
                                        IApplicationDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<List<StreamersVM>> Handle(GetStreamerListQuery request, CancellationToken cancellationToken)
        {
            var streamers = await _dbContext.Streamers
                                            .AsNoTracking()
                                            .ToListAsync(cancellationToken: cancellationToken);

            return _mapper.Map<List<StreamersVM>>(streamers);
        }
    }
}
