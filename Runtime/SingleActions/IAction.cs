using System;
using Cysharp.Threading.Tasks;

namespace Laphed.ScenariosUI.SingleActions
{
    interface IAction { }

    class VoidAction : IAction
    {
        private readonly Action action;
        
        public VoidAction(Action action)
        {
            this.action = action;
        }

        public void Invoke()
        {
            action.Invoke();
        }
    }

    class TaskAction : IAction
    {
        public Func<UniTask> Task => task;
        
        private readonly Func<UniTask> task;

        public TaskAction(Func<UniTask> task)
        {
            this.task = task;
        }
    }
}
