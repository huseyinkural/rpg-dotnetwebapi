using System.Collections.Generic;
using System.Threading.Tasks;
using rpg_webapi.Models;

namespace rpg_webapi.Services.CharacterService
{
    public interface ICharacterService
    {
         Task<ServiceResponse<List<Character>>> GetAllCharacters();         
         Task<ServiceResponse<Character>> GetCharacterById(int id);
         Task<ServiceResponse<List<Character>>> AddCharacter(Character newCharacter);        
         
    }
}