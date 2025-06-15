using NepalTrails.Data;
using NepalTrails.Models.Domain;
using NepalTrails.Repositories.Interfaces;

namespace NepalTrails.Repositories.Implementations
{
    public class TrailRepository : ITrailRepository
    {
        private readonly NepalTrailsDbContext dbContext;

        public TrailRepository(NepalTrailsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Trail> CreateAsync(Trail trail)
        {
            await dbContext.AddAsync(trail);
            await dbContext.SaveChangesAsync();
            return trail;
        }
    }
}
