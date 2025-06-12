using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NepalTrails.Data;
using NepalTrails.Models.Domain;
using NepalTrails.Models.DTO;

namespace NepalTrails.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly NepalTrailsDbContext dbcontext;

        public RegionsController(NepalTrailsDbContext dbcontext)
        {
           this.dbcontext = dbcontext;
        }
        [HttpGet]
        public IActionResult GetAllRegion()
        {
           
            var regions =dbcontext.Regions.ToList();

            var regionsDTO = new List<RegionDTO>();

            foreach (var region in regions)
            {
                regionsDTO.Add(new RegionDTO()
                {
                    Id = region.Id,
                    Code = region.Code,
                    Name = region.Name,
                    RegionImageUrl = region.RegionImageUrl
                });
            }
            return Ok(regionsDTO);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetById([FromRoute]Guid id)
        {
            var region = dbcontext.Regions.Where(r => r.Id == id).FirstOrDefault();

            if (region == null)
            {
                return NotFound();
            }

            var regionsDTO = new RegionDTO
            {
                Id = region.Id,
                Code = region.Code,
                Name = region.Name,
                RegionImageUrl = region.RegionImageUrl
            };

            return Ok(regionsDTO);
        }

        [HttpPost]
        public IActionResult Create([FromBody] AddRegionRequestDTO addRegionRequestDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var region = new Region
            {
                Code = addRegionRequestDTO.Code,
                Name = addRegionRequestDTO.Name,
                RegionImageUrl = addRegionRequestDTO.RegionImageUrl
            };

            dbcontext.Regions.Add(region);
            dbcontext.SaveChanges();

            var regionsDTO = new RegionDTO
            {
                Id = region.Id,
                Code = region.Code,
                Name = region.Name,
                RegionImageUrl = region.RegionImageUrl
            };


            return CreatedAtAction(nameof(GetById), new {id= regionsDTO.Id}, regionsDTO);

        }

        //update region 
        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDTO updateRegionRequestDTO )
        {
            var region = dbcontext.Regions.FirstOrDefault(r => r.Id == id);
            if (region == null)
                return BadRequest(ModelState);
            region.Code = updateRegionRequestDTO.Code;
            region.Name = updateRegionRequestDTO.Name;
            region.RegionImageUrl = updateRegionRequestDTO.RegionImageUrl;
            dbcontext.SaveChanges();

            var regionsDTO = new RegionDTO
            {
                Id = region.Id,
                Code = region.Code,
                Name = region.Name,
                RegionImageUrl = region.RegionImageUrl
            };


            return Ok(regionsDTO);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult Delete([FromRoute] Guid id)
        {
            var region = dbcontext.Regions.FirstOrDefault(r=>r.Id == id);
            if (region == null)
                return BadRequest(ModelState);
            dbcontext.Regions.Remove(region);
            dbcontext.SaveChanges();
            var regionsDTO = new RegionDTO
            {
                Id = region.Id,
                Code = region.Code,
                Name = region.Name,
                RegionImageUrl = region.RegionImageUrl
            };

            return Ok(regionsDTO);
            
        }
        
    }
}
