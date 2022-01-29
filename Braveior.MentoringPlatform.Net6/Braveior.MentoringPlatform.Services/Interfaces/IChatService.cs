using Braveior.MentoringPlatform.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Braveior.MentoringPlatform.Services.Interfaces
{
    public interface IChatService
    {
        List<MessageDTO> GetMessages(long InstitutionId);
        void PostMessage(MessageDTO messageDTO);
    }
}
