using AutoMapper;
using Braveior.MentoringPlatform.DTO;
using Braveior.MentoringPlatform.Repository;
using Braveior.MentoringPlatform.Repository.Models;
using Braveior.MentoringPlatform.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Braveior.MentoringPlatform.Services
{
    public class ChatService : IChatService
    {
        private readonly IMapper _mapper;

        public ChatService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public List<MessageDTO> GetMessages(long channelid)
        {
            using (var db = new braveiordbContext())
            {
                var messages = db.Messages.Where(t => t.ChannelId == channelid);
                return _mapper.Map<List<MessageDTO>>(messages);
            }
        }

        public void PostMessage(MessageDTO messageDTO)
        {
            Message newMessage = new Message()
            {
                MessageContent = messageDTO.MessageContent,
                ChannelId = messageDTO.ChannelId,
                UserId = messageDTO.UserId,
                BraveiorLike = false,
                MessageLike = 0
            };
            using (var db = new braveiordbContext())
            {
                db.Messages.Add(newMessage);
                db.SaveChanges();
            }
        }
    }
}
