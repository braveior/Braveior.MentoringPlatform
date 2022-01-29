using Braveior.MentoringPlatform.DTO;

namespace Braveior.MentoringPlatform.WA.Client.State.Common
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
