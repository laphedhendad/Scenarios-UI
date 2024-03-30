namespace Laphed.ScenariosUI
{
    public class LinkedScenarioCancellationToken : ScenarioCancellationToken
    {
        public override bool IsCancellationRequested =>
            base.IsCancellationRequested || parentToken.IsCancellationRequested;

        private readonly ScenarioCancellationToken parentToken;

        public LinkedScenarioCancellationToken(ScenarioCancellationToken parentToken)
        {
            this.parentToken = parentToken;
        }
    }
}
