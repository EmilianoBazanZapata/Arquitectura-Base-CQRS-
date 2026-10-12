using Application.Exceptions;
using AutoMapper;
using Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Features.Streamers.Commands.DeleteStreamer
{
    public record DeleteStreamerCommand(int Id) : IRequest;

    public class DeleteStreamerCommandHandler : IRequestHandler<DeleteStreamerCommand>
    {
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly IApplicationDbContext _dbContext;

        public DeleteStreamerCommandHandler(IMapper mapper,
                                            ILogger<DeleteStreamerCommandHandler> logger,
                                            IApplicationDbContext dbContext)
        {
            _mapper = mapper;
            _logger = logger;
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(DeleteStreamerCommand request, CancellationToken cancellationToken)
        {
            var streamerToDelete = await _dbContext.Streamers.FirstOrDefaultAsync(s => s.Id == request.Id, cancellationToken);

            if (streamerToDelete is null)
            {
                _logger.LogError($"{request.Id} streamer no existe en el sistema");
                throw new NotFoundException(nameof(Streamer), request.Id);
            }

            _dbContext.Streamers.Remove(streamerToDelete);
            await _dbContext.SaveChangesAsync(cancellationToken);

            _logger.LogInformation($"El {request.Id} streamer fue elminiado con exito");

            return Unit.Value;
        }
    }
}
