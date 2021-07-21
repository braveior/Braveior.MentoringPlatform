using Braveior.MentoringPlatform.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Braveior.MentoringPlatform.Services.Interfaces
{
    public interface ILoginService
    {
        UserDTO Login(LoginDTO user);
        Task<UserDTO> GetUserFromAccessToken(string accessToken);

        void Register(UserDTO userDTO);
    }
}
