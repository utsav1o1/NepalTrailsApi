using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NepalTrails.Data;
using NepalTrails.Models.Domain;
using NepalTrails.Models.DTO;
using NepalTrails.Repositories.Interfaces;
using System.Xml.Linq;

namespace NepalTrails.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly NepalTrailsDbContext dbcontext;
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionsController(NepalTrailsDbContext dbcontext, IRegionRepository regionRepository, IMapper mapper)
        {
           this.dbcontext = dbcontext;
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllRegion()
        {

            var regions = await regionRepository.GetAllAsync();

            //var regionsDTO = new List<RegionDTO>();
            var regionsDTO = mapper.Map<List<RegionDTO>>(regions);
            return Ok(regionsDTO);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute]Guid id)
        {
            var region =await regionRepository.GetAsync(id);

            if (region == null)
            {
                return NotFound();
            }

            var regionsDTO= mapper.Map<RegionDTO>(region);

            return Ok(regionsDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDTO addRegionRequestDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var region = mapper.Map<Region>(addRegionRequestDTO);
           
            region = await regionRepository.CreateAsync(region);

            var regionsDTO = mapper.Map<RegionDTO>(region);
            


            return CreatedAtAction(nameof(GetById), new {id= regionsDTO.Id}, regionsDTO);

        }

        //update region 
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDTO updateRegionRequestDTO )
        {
            var region = mapper.Map<Region>(updateRegionRequestDTO);

            region = await regionRepository.UpdateAsync(id, region);

            if (region == null)
                return NotFound();

            var regionsDTO = mapper.Map<UpdateRegionRequestDTO>(region);

            return Ok(regionsDTO);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
           
            var region = await regionRepository.DeleteAsync(id);
            if (region == null)
                return NotFound();

            var regionsDTO = mapper.Map<RegionDTO>(region);

            return Ok(regionsDTO);
            
        }
        
    }
}
