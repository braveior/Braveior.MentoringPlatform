using Braveior.MentoringPlatform.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Braveior.MentoringPlatform.Client.Services
{
    public interface IProfileService
    {
        Task<List<AssetDTO>> GetAssets(long userId); 

    }
}
