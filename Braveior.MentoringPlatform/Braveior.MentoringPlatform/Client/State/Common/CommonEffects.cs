using Fluxor;
using System.Threading.Tasks;

namespace Braveior.MentoringPlatform.Client.State.Common
{
	public class CommonEffects
	{


		public CommonEffects()
		{

		}

		[EffectMethod]
		public async Task HandleAction(CommonAction action, IDispatcher dispatcher)
		{
			dispatcher.Dispatch(new CommonResultAction(action.LoggedInUser));
		}
	}
}
