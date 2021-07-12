using Braveior.MentoringPlatform.Client.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Braveior.MentoringPlatform.Client.Services
{
    public interface IKanboardService
    {
        Task<List<TaskDTO>> GetTasks(long kanboardId);
    
    }
}
