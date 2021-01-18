using System;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using rpg_webapi.Data;
using rpg_webapi.Dtos.Character;
using rpg_webapi.Dtos.Weapon;
using rpg_webapi.Models;

namespace rpg_webapi.Services.WeaponService
{
    public class WeaponService : IWeaponService
    {
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContexAccessor;
        private readonly IMapper _mapper;

        public WeaponService(DataContext context, IHttpContextAccessor httpContexAccessor, IMapper mapper)
        {
            _context = context;
            _httpContexAccessor = httpContexAccessor;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<GetCharacterDto>> AddWeapon(AddWeaponDto newWeapon)
        {
            ServiceResponse<GetCharacterDto> response = new ServiceResponse<GetCharacterDto>();
            try
            {
                Character character = await _context.Characters
                    .FirstOrDefaultAsync(c => c.Id == newWeapon.CharacterId && 
                    c.User.Id == int.Parse(_httpContexAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)));

                if(character == null)
                {
                    response.Success = false;
                    response.Message = "Character not found.";
                    return response;
                }
                Weapon weapon = new Weapon
                {
                    Name = newWeapon.Name,
                    Damage = newWeapon.Damage,
                    Character = character
                };

                await _context.Weapons.AddAsync(weapon);
                await _context.SaveChangesAsync();

                response.Data = _mapper.Map<GetCharacterDto>(character);                   

            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                
            }
            return response;
        }
    }
}