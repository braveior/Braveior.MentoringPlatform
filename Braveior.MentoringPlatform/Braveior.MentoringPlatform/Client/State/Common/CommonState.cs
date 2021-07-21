using Braveior.MentoringPlatform.DTO;

namespace Braveior.MentoringPlatform.Client.State.Common
{
	public class CommonState
	{

		public UserDTO LoggedInUser { get; }


		public CommonState(UserDTO loggedInUser)
		{
			LoggedInUser = loggedInUser;
		}
	}
}
