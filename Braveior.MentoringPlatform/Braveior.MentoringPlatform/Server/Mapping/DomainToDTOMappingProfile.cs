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
            CreateMap<Story, StoryDTO>();
            CreateMap<User, UserDTO>();
            CreateMap<Message, MessageDTO>().ForMember(dto=>dto.UserName,opt=>opt.MapFrom(x=>x.User.Name));
        }
    }
}
