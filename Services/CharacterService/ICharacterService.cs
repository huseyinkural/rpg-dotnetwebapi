using System.Collections.Generic;
using System.Threading.Tasks;
using rpg_webapi.Dtos.Character;
using rpg_webapi.Models;

namespace rpg_webapi.Services.CharacterService
{
    public interface ICharacterService
    {
         Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters();         
         Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id);
         Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter);       
         Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updatedCharacter);
         Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id);
         
    }
}