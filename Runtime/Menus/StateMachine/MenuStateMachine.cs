using System;

namespace Laphed.ScenariosUI.Menus
{
    class MenuStateMachine
    {
        public BaseState CurrentState => currentState;

        private readonly IMenuNextStateRepository menuNextStateRepository;
        private BaseState currentState;

        public MenuStateMachine(IMenuNextStateRepository menuNextStateRepository, BaseState initialState)
        {
            this.menuNextStateRepository = menuNextStateRepository;
            currentState = initialState;
            currentState.OnEnter();

            menuNextStateRepository.onNextStateContextSet += OnMenuNextStateRepositoryContextSet;
        }

        private void OnMenuNextStateRepositoryContextSet()
        {
            currentState.OnExit();

            IMenuNextStateRepository.NextStateContext nextStateContext =
                menuNextStateRepository.ConsumeNextStateContext();

            BaseState nextState = nextStateContext.nextState;

            if (currentState.GetType() == nextState.GetType())
            {
                throw new Exception("Attempt to change activityComponent to the same state")
                {
                    Data =
                    {
                        { "CurrentState", currentState.GetType() },
                        { "NextState", nextState.GetType() }
                    }
                };
            }

            currentState = nextState;
            currentState.OnEnter();
        }
    }
}
