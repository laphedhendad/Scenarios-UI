using System;

namespace Laphed.ScenariosUI.Menus
{
    interface IMenuNextStateRepository
    {
        public class NextStateContext
        {
            public BaseState nextState;
        }

        event Action onNextStateContextSet;

        NextStateContext ConsumeNextStateContext();
    }
}
