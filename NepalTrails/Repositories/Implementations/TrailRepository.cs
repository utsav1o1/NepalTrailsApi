using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
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
            await dbContext.Trails.AddAsync(trail);
            await dbContext.SaveChangesAsync();
            return trail;
        }

        public async Task<List<Trail>> GetAllAsync()
        {
            return await dbContext.Trails.ToListAsync();
            
        }
    }
}
