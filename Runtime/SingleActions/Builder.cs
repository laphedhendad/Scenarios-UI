using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;

namespace Laphed.ScenariosUI.SingleActions
{
    public class Builder
    {
        private readonly Dictionary<IResettableCondition, IAction> actions = new();

        public Builder AddTaskAction(IResettableCondition condition, Func<UniTask> task)
        {
            actions.Add(condition, new TaskAction(task));
            return this;
        }

        public Builder AddAction(IResettableCondition condition, Action action)
        {
            actions.Add(condition, new VoidAction(action));
            return this;
        }
        
        public SingleActionsExecutor Build()
        {
            var conditionActionPairs = new ConditionActionPairs(
                actions.Select(
                    kv => new ConditionActionPairs.ConditionActionPair
                    {
                        condition = kv.Key,
                        action = kv.Value
                    }
                ).ToArray()
            );

            return new SingleActionsExecutor(conditionActionPairs);
        }
    }
}
