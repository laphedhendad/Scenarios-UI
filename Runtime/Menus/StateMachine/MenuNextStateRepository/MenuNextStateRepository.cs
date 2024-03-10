using System;

namespace Laphed.ScenariosUI.Menus
{
    class MenuNextStateRepository
        : IMenuStateChanger,
          IMenuNextStateRepository
    {
        public event Action onNextStateContextSet;

        private IMenuNextStateRepository.NextStateContext nextStateContext;

        public IMenuNextStateRepository.NextStateContext ConsumeNextStateContext()
        {
            if (nextStateContext == null)
            {
                throw new Exception($"{nameof(MenuNextStateRepository)}: nothing to consume");
            }

            IMenuNextStateRepository.NextStateContext context = nextStateContext;
            nextStateContext = null;
            return context;
        }

        public void SetNextState(BaseState nextState)
        {
            if (nextStateContext != null)
            {
                throw new Exception($"{nameof(Menus)}: next menu state already set")
                {
                    Data =
                    {
                        { "SetNextState", nextStateContext.nextState.GetType() },
                        { "NewNextState", nextState.GetType() }
                    }
                };
            }

            nextStateContext = new IMenuNextStateRepository.NextStateContext
            {
                nextState = nextState
            };

            onNextStateContextSet?.Invoke();
        }
    }
}
