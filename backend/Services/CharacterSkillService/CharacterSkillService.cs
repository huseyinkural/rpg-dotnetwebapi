using System;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using rpg_webapi.Data;
using rpg_webapi.Dtos.Character;
using rpg_webapi.Dtos.CharacterSkill;
using rpg_webapi.Models;

namespace rpg_webapi.Services.CharacterSkillService
{
    public class CharacterSkillService : ICharacterSkillService
    {
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public CharacterSkillService(DataContext context, IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<GetCharacterDto>> AddCharacterSkill(AddCharacterSkillDto newCharacterSkill)
        {
            ServiceResponse<GetCharacterDto> response = new ServiceResponse<GetCharacterDto>();

            try
            {
                Character character = await _context.Characters
                    .Include(c => c.Weapon)
                    .Include(c => c.CharacterSkills).ThenInclude(cs => cs.Skill)
                    .FirstOrDefaultAsync(c => c.Id == newCharacterSkill.CharacterId &&
                    c.User.Id == int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)));

                if(character == null)
                {
                    response.Success = false;
                    response.Message = "Character not found.";
                    return response;
                }

                Skill skill = await _context.Skills
                    .FirstOrDefaultAsync(s => s.Id == newCharacterSkill.SkillId);
                if(skill == null) 
                {
                    response.Success = false;
                    response.Message = "Skill not found.";
                    return response;
                }

                CharacterSkill characterSkill = new CharacterSkill
                {
                    Character = character,
                    Skill = skill
                };

                await _context.CharacterSkills.AddAsync(characterSkill);
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