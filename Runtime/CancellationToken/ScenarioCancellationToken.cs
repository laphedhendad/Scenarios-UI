using System;
using System.Linq;
using System.Threading;

namespace Laphed.ScenariosUI
{
    public class ScenarioCancellationToken : IDisposable
    {
        public bool IsCancellationRequested =>
            dotNetToken.IsCancellationRequested
         || linkedTokens.All(token => token.IsCancellationRequested)
         || linkedDotNetTokens.All(token => token.IsCancellationRequested);
        
        public CancellationToken DotNetToken => dotNetToken;
        
        private readonly CancellationTokenSource cancellationTokenSource;
        private readonly CancellationToken dotNetToken;
        private readonly ScenarioCancellationToken[] linkedTokens;
        private readonly CancellationToken[] linkedDotNetTokens;

        public ScenarioCancellationToken()
        {
            cancellationTokenSource = new CancellationTokenSource();
            dotNetToken = cancellationTokenSource.Token;
        }

        public ScenarioCancellationToken(params ScenarioCancellationToken[] linkedTokens)
        {
            this.linkedTokens = linkedTokens;
            cancellationTokenSource = new CancellationTokenSource();
            dotNetToken = cancellationTokenSource.Token;
        }

        public ScenarioCancellationToken(params CancellationToken[] linkedTokens)
        {
            linkedDotNetTokens = linkedTokens;
            cancellationTokenSource = new CancellationTokenSource();
            dotNetToken = cancellationTokenSource.Token;
        }

        public void Cancel()
        {
            cancellationTokenSource.Cancel();
        }

        public void Dispose()
        {
            cancellationTokenSource.Dispose();
        }
    }
}
