using Application.Exceptions;
using AutoMapper;
using Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Streamers.Commands.Queries.GetStreamerByName
{
    public record GetStreamerByNameQuery : IRequest<StreamersVM>
    {
        public string _UserName { get; set; } = string.Empty;
        public GetStreamerByNameQuery(string streammer)
        {
            _UserName = streammer ?? throw new ArgumentNullException(nameof(streammer));
        }
    };

    public class GetStreamerByNameQueryHandler : IRequestHandler<GetStreamerByNameQuery, StreamersVM>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _dbContext;


        public GetStreamerByNameQueryHandler(IMapper mapper,
                                        IApplicationDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<StreamersVM> Handle(GetStreamerByNameQuery request, CancellationToken cancellationToken)
        {
            var streamer = await _dbContext.Streamers
                                            .Where(s => s.Name == request._UserName)
                                            .AsNoTracking()
                                            .FirstOrDefaultAsync();

            return streamer is null ? 
                   throw new NotFoundException(nameof(Streamer), request._UserName) : 
                   _mapper.Map<StreamersVM>(streamer);
        }
    }
}
