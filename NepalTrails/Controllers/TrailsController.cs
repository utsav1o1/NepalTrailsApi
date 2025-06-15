using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NepalTrails.Data;
using NepalTrails.Models.Domain;
using NepalTrails.Models.DTO;
using NepalTrails.Repositories.Implementations;

namespace NepalTrails.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrailsController : ControllerBase
    {
        private readonly NepalTrailsDbContext dbcontext;
        private readonly IMapper mapper;
        private readonly TrailRepository trailRepository;

        public TrailsController(NepalTrailsDbContext dbcontext, IMapper mapper, TrailRepository trailRepository) 
        {
            this.dbcontext = dbcontext;
            this.mapper = mapper;
            this.trailRepository = trailRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddTrailRequestDTO addTrailRequestDTO)
        {
            //mapping dto to model 
            var trail = mapper.Map<Trail>(addTrailRequestDTO);
            await trailRepository.CreateAsync(trail);
            
            return Ok(mapper.Map<TrailDTO>(trail));
        }
    }
}
