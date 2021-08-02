using Braveior.MentoringPlatform.DTO;

namespace Braveior.MentoringPlatform.Client.State.Common
{
    public class CommonAction
    {
        public UserDTO LoggedInUser;

        public CommonAction(UserDTO user)
        {
            LoggedInUser = user;
        }
    }
}
