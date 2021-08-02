using Braveior.MentoringPlatform.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Braveior.MentoringPlatform.Services.Interfaces
{
    public interface IProfileService
    {
        ProfileDTO GetProfile(long userId);

        List<AssetDTO> GetAssets(long userId);
    }
}
