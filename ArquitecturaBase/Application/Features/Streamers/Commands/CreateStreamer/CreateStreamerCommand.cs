using AutoMapper;
using Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.Streamers.Commands.CreateStreamer
{
    public record CreateStreamerCommand(string Name) : IRequest<int>;

    public class CreateStreamerCommandHandler : IRequestHandler<CreateStreamerCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<CreateStreamerCommandHandler> _logger;
        private readonly IApplicationDbContext _dbContext;

        public CreateStreamerCommandHandler(IMapper mapper,
                                            ILogger<CreateStreamerCommandHandler> logger,
                                            IApplicationDbContext dbContext)
        {
            _mapper = mapper;
            _logger = logger;
            _dbContext = dbContext;
        }

        public async Task<int> Handle(CreateStreamerCommand request, CancellationToken cancellationToken)
        {
            var streamerEntity = _mapper.Map<Streamer>(request);

            _dbContext.Streamers.Add(streamerEntity);

            await _dbContext.SaveChangesAsync(cancellationToken);

            _logger.LogInformation($"Streamer {streamerEntity.Id} fue creado exitosamente");

            return streamerEntity.Id;
        }
    }
}