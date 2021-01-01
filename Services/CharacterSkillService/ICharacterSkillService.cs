using System.Threading.Tasks;
using rpg_webapi.Dtos.Character;
using rpg_webapi.Dtos.CharacterSkill;
using rpg_webapi.Models;

namespace rpg_webapi.Services.CharacterSkillService
{
    public interface ICharacterSkillService
    {
        Task<ServiceResponse<GetCharacterDto>> AddCharacterSkill(AddCharacterSkillDto newCharacterSkill);                 
    }
}