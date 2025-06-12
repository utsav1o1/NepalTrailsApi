using Microsoft.EntityFrameworkCore;
using NepalTrails.Models.Domain;

namespace NepalTrails.Data
{
    public class NepalTrailsDbContext : DbContext
    {
        public NepalTrailsDbContext(DbContextOptions<NepalTrailsDbContext> options) : base(options) { }
        

        public  DbSet<Region> Regions { get; set; }

        public DbSet<Difficulty>  Difficulties { get; set; }    

        public DbSet<Trail> Trails { get; set; }

}

    }