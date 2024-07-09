using System;
using System.Threading;

namespace Laphed.ScenariosUI
{
    public class LinkedCancellationTokenSource : IDisposable
    {
        public CancellationToken Token => internalCancellationTokenSource.Token;
        public bool IsCancellationRequested => internalCancellationTokenSource.IsCancellationRequested;

        private readonly CancellationTokenSource internalCancellationTokenSource;
        private readonly CancellationTokenRegistration parentTokenRegistration;

        public LinkedCancellationTokenSource(CancellationToken parentToken)
        {
            internalCancellationTokenSource = new CancellationTokenSource();

            parentTokenRegistration = parentToken.Register(Cancel);
        }

        public void Cancel()
        {
            internalCancellationTokenSource.Cancel();
        }

        public void Dispose()
        {
            parentTokenRegistration.Dispose();
            internalCancellationTokenSource.Dispose();
        }
    }
}
