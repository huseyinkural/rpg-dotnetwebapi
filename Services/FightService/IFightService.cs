using System.Collections.Generic;
using System.Threading.Tasks;
using rpg_webapi.Dtos.Fight;
using rpg_webapi.Models;

namespace rpg_webapi.Services.FightService
{
    public interface IFightService
    {
        Task<ServiceResponse<AttackResultDto>> WeaponAttack(WeaponAttackDto request);
        Task<ServiceResponse<AttackResultDto>> SkillAttack(SkillAttackDto request);
        Task<ServiceResponse<FightResultDto>> Fight(FightRequestDto request);

        Task<ServiceResponse<List<HighScoreDto>>> GetHighscore();
    }
}