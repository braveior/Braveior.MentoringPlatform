using Braveior.MentoringPlatform.Client.DTO;

namespace Braveior.MentoringPlatform.Client.State.Common
{
    public class CommonResultAction
    {
        public UserDTO LoggedInUser { get; }


        public CommonResultAction(UserDTO user)
        {
            LoggedInUser = user;
        }
    }
}
