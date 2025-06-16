using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NepalTrails.Data;
using NepalTrails.Models.Domain;
using NepalTrails.Models.DTO;
using NepalTrails.Repositories.Interfaces;

namespace NepalTrails.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrailsController : ControllerBase
    {
        private readonly NepalTrailsDbContext dbcontext;
        private readonly IMapper mapper;
        private readonly ITrailRepository trailRepository;

        public TrailsController(NepalTrailsDbContext dbcontext, IMapper mapper, ITrailRepository trailRepository) 
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


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var trails = await trailRepository.GetAllAsync();
            return Ok(mapper.Map<List<TrailDTO>>(trails));
        }
    }
}
