using NepalTrails.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace NepalTrails.Models.DTO
{
    public class AddTrailRequestDTO
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public double LengthInKm { get; set; }

        [Url]
        public string? TrailImageUrl { get; set; }

        public Guid DifficultyId { get; set; }

        public Guid RegionId { get; set; }

    }
}
