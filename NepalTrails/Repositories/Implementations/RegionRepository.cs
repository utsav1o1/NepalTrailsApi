using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using NepalTrails.Data;
using NepalTrails.Models.Domain;
using NepalTrails.Models.DTO;
using NepalTrails.Repositories.Interfaces;

namespace NepalTrails.Repositories.Implementations
{
    public class RegionRepository : IRegionRepository
    {
        private readonly NepalTrailsDbContext dbContext;

        public RegionRepository( NepalTrailsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<List<Region>> GetAllAsync()
        {
            return await dbContext.Regions.ToListAsync();

        }

        public async Task<Region?> GetAsync(Guid regionId)
        {
            return await dbContext.Regions.FirstOrDefaultAsync(r=>r.Id == regionId);
        }


        public async Task<Region> CreateAsync(Region region)
        {
            dbContext.Regions.Add(region);
            await dbContext.SaveChangesAsync();
            return region;
        }

        public async Task<Region?> UpdateAsync( Guid id, Region region)
        {
            
            var existingregion = await dbContext.Regions.FirstOrDefaultAsync(r => r.Id == id);
            if (existingregion == null)
                return null;

            existingregion.Code = region.Code;
            existingregion.Name = region.Name;
            existingregion.RegionImageUrl = region.RegionImageUrl;
            await dbContext.SaveChangesAsync();
            return existingregion;
        }

        public async Task<Region?> DeleteAsync(Guid id)
        {
            var existingregion = await dbContext.Regions.FirstOrDefaultAsync(r=>r.Id==id);
            if (existingregion == null)
                return null;

            dbContext.Regions.Remove(existingregion);
            await dbContext.SaveChangesAsync();
            return existingregion;
        }

       

        
       
    }
}
