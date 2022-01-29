using Braveior.MentoringPlatform.DTO;

namespace Braveior.MentoringPlatform.WA.Client.State.Common
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
