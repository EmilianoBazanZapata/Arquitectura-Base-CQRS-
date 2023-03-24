using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Streamer> Streamers { get;}
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
