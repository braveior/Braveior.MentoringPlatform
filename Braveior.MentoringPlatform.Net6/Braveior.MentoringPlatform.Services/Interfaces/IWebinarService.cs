using Braveior.MentoringPlatform.DTO;
using Braveior.MentoringPlatform.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Braveior.MentoringPlatform.Services.Interfaces
{
    public interface IWebinarService
    {
        BootCampActivityDTO GetBootCampActivity(long bootCampActivityId);
        List<BootCampActivityDTO> GetBootCampActivities();

        List<BootCampDTO> GetBootCamps();
        void AddBootCampActivity(BootCampActivityDTO bootCampActivityDTO);
        void UpdateBootCampActivity(BootCampActivityDTO bootCampActivityDTO);
        void DeleteBootCampActivity(long bootCampActivityId);

    }
}
