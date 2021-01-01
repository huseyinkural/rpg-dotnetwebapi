using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rpg_webapi.Services.FightService;

namespace rpg_webapi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class FightController : ControllerBase
    {
        private readonly IFightService _fightService;

        public FightController(IFightService fightService)
        {
            _fightService = fightService;
        }
        
    }
}