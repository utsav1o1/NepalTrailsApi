using System.ComponentModel.DataAnnotations;

namespace NepalTrails.Models.Domain
{
    public class Region
    {
      public Guid Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        [Url]
        public string? RegionImageUrl { get; set; }


    }
}
