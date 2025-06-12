using System.ComponentModel.DataAnnotations;

namespace NepalTrails.Models.DTO
{
    public class UpdateRegionRequestDTO
    {
        public string Code { get; set; }

        public string Name { get; set; }

        [Url]
        public string? RegionImageUrl { get; set; }
    }
}
