using AutoMapper;
using Braveior.MentoringPlatform.DTO;
using Braveior.MentoringPlatform.Repository.Models;
using System.Linq;

namespace Braveior.MentoringPlatform.Server.MApping
{
    /// <summary>
    /// Auto Mapper Mapping Configuration
    /// </summary>
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            //Mapping the Member MongoDB entity to the MemberDTO. 
            CreateMap<Task, TaskDTO>().ForMember(dto => dto.Users, opt => opt.MapFrom(x => x.UserTasks.Select(y => y.User).ToList()));
            CreateMap<User, UserDTO>();
            CreateMap<Institution, InstitutionDTO>();
            CreateMap<Group, GroupDTO>();
            CreateMap<Story, StoryDTO>().ForMember(dto => dto.Tasks, opt => opt.MapFrom(x => x.Tasks.ToList()));
            CreateMap<Kanboard, KanboardDTO>();
            CreateMap<UserSkill, UserSkillDTO>();
            CreateMap<Asset, AssetDTO>();
            //CreateMap<Message, MessageDTO>().ForMember(dto=>dto.UserName,opt=>opt.MapFrom(x=>x.User.Name));
        }
    }
}
