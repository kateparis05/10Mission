using Microsoft.AspNetCore.Mvc;
using _10Mission.Data;

namespace _10Mission.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BowlersController : ControllerBase
    {
        private readonly IBowlingRepository _repository;
        
        public BowlersController(IBowlingRepository repository)
        {
            _repository = repository;
        }
        
        [HttpGet]
        public IActionResult Get()
        {
            // Get bowlers from Marlins and Sharks teams ONLY, as specified in requirements
            return Ok(_repository.GetBowlersWithTeam(new[] { "Marlins", "Sharks" }));
        }
    }
}