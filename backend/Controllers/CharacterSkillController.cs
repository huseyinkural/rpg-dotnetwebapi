using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rpg_webapi.Dtos.CharacterSkill;
using rpg_webapi.Services.CharacterSkillService;

namespace rpg_webapi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CharacterSkillController : ControllerBase
    {
        private readonly ICharacterSkillService _characterSkillService;

        public CharacterSkillController(ICharacterSkillService characterSkillService)
        {
            _characterSkillService = characterSkillService;
        }

        [HttpPost]
        public async Task<IActionResult> AddCharacterSkill(AddCharacterSkillDto newCharacterSkill)
        {
            return Ok(await _characterSkillService.AddCharacterSkill(newCharacterSkill));
        }
        
    }
}