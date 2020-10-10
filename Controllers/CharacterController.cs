using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using rpg_webapi.Models;
using rpg_webapi.Services.CharacterService;

namespace rpg_webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;
      

        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }
    
        
        [HttpGet("GetAll")]
        public async Task<IActionResult> Get(){
            return Ok(await _characterService.GetAllCharacters());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id) {
            return Ok(await _characterService.GetCharacterById(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddCharacter(Character newCharacter){           
            return Ok(await _characterService.AddCharacter(newCharacter));
        }
        
    }
}