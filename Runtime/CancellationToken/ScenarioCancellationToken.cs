namespace Laphed.ScenariosUI
{
    public class ScenarioCancellationToken
    {
        public virtual bool IsCancellationRequested => isCancellationRequested;
        
        protected bool isCancellationRequested;

        public void Cancel()
        {
            isCancellationRequested = true;
        }
    }
}
