using NepalTrails.Models.Domain;

namespace NepalTrails.Repositories.Interfaces
{
    public interface ITrailRepository
    {
        Task<Trail> CreateAsync(Trail trail);
    }
}
