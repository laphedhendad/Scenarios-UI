using System.Threading;

namespace Laphed.ScenariosUI
{
    public class DotNetLinkedScenarioCancellationToken : ScenarioCancellationToken
    {
        public override bool IsCancellationRequested =>
            base.IsCancellationRequested || parentToken.IsCancellationRequested;

        private readonly CancellationToken parentToken;

        public DotNetLinkedScenarioCancellationToken(CancellationToken parentToken)
        {
            this.parentToken = parentToken;
        }
    }
}
