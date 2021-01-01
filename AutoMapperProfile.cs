using System.Linq;
using AutoMapper;
using rpg_webapi.Dtos.Character;
using rpg_webapi.Dtos.Skill;
using rpg_webapi.Dtos.Weapon;
using rpg_webapi.Models;

namespace rpg_webapi
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character,GetCharacterDto>()
                .ForMember(dto => dto.Skills, c => c.MapFrom(c => c.CharacterSkills.Select(cs => cs.Skill)));
            CreateMap<AddCharacterDto,Character>();
            CreateMap<Weapon,GetWeaponDto>();
            CreateMap<Skill, GetSkillDto>();
        }
        
    }
}