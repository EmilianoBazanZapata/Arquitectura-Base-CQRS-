using Application.Exceptions;
using AutoMapper;
using Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Features.Streamers.Commands.UpdateStreamer
{
    public record UpdateStreamerCommand(int Id, string Name) : IRequest;

    public class UpdateStreamerCommandHandler : IRequestHandler<UpdateStreamerCommand>
    {
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly IApplicationDbContext _dbContext;

        public UpdateStreamerCommandHandler(IMapper mapper,
                                            ILogger<UpdateStreamerCommandHandler> logger,
                                            IApplicationDbContext dbContext)
        {
            _mapper = mapper;
            _logger = logger;
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(UpdateStreamerCommand request, CancellationToken cancellationToken)
        {
            var streamerToUpdate = await _dbContext.Streamers.FirstOrDefaultAsync(s => s.Id == request.Id, cancellationToken: cancellationToken);

            if (streamerToUpdate is null)
            {
                _logger.LogError($"no se encontro el streamer id {request.Id}");
                throw new NotFoundException(nameof(Streamer), request.Id);
            }

            _mapper.Map(request, streamerToUpdate, typeof(UpdateStreamerCommand), typeof(Streamer));

            await _dbContext.SaveChangesAsync(cancellationToken);

            _logger.LogInformation($"La operacion fue exitosa actualizando el streamer {request.Id}");

            return Unit.Value;
        }
    }
}
