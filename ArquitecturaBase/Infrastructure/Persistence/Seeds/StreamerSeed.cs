using Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Persistence.Seeds
{
    public class StreamerSeed
    {
        public static async Task StreamerSeedAsync(ApplicationDbContext context,
                                                   ILogger<StreamerSeed> logger) 
        {
            if (!context!.Streamers!.Any()) 
            {
                context!.Streamers!.AddRange(GetPreconfiguredStreamer());
                await context!.SaveChangesAsync();
                logger.LogInformation("Se esta registrando los STREAMERS al contexto {context}", typeof(ApplicationDbContext).Name);
            }
        }

        private static IEnumerable<Streamer> GetPreconfiguredStreamer()
        {
            return new List<Streamer>
            {
                new Streamer
                {
                    CreatedBy = "Emiliano",
                    Name = "Streamer 1"
                },
                new Streamer
                {
                    CreatedBy = "Emiliano",
                    Name = "Streamer 2"
                }
            };
        }
    }
}
