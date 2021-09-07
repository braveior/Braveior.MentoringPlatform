using Braveior.MentoringPlatform.DTO;
using System.Threading.Tasks;

namespace Braveior.MentoringPlatform.Client.Services
{
    public interface ILoginService
    {
        public Task<UserDTO> LoginAsync(LoginDTO userDTO);
        public Task<UserDTO> GetUserByAccessTokenAsync(string accessToken);


    }
}
