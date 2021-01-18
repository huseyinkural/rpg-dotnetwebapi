using System.Threading.Tasks;
using rpg_webapi.Dtos.Character;
using rpg_webapi.Dtos.Weapon;
using rpg_webapi.Models;

namespace rpg_webapi.Services.WeaponService
{
    public interface IWeaponService
    {
        Task<ServiceResponse<GetCharacterDto>> AddWeapon(AddWeaponDto newWeapon);
    }
}