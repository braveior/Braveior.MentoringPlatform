using Braveior.MentoringPlatform.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Braveior.MentoringPlatform.Client.Services
{
    public interface IWebinarService
    {
        Task<BootCampActivityDTO> GetBootCampActivity(long bootCampActivityId);
        Task<List<BootCampActivityDTO>> GetBootCampActivities();
        Task<List<BootCampDTO>> GetBootCamps();
        Task AddBootCampActivity(BootCampActivityDTO bootCampActivityDTO);
        Task UpdateBootCampActivity(BootCampActivityDTO bootCampActivityDTO);
        Task DeleteBootCampActivity(long bootCampActivityId);
    }
}
