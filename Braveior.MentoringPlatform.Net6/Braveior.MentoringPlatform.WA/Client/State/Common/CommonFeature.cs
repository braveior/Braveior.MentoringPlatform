using Fluxor;

namespace Braveior.MentoringPlatform.WA.Client.State.Common
{
	public class CommonFeature : Feature<CommonState>
	{
        public override string GetName() => "Common";
        protected override CommonState GetInitialState() =>
            new CommonState(
                loggedInUser: null

               );
    }
}
