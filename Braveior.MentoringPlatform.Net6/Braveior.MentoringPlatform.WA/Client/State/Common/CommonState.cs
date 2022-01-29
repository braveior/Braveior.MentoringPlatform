using Braveior.MentoringPlatform.DTO;

namespace Braveior.MentoringPlatform.WA.Client.State.Common
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
