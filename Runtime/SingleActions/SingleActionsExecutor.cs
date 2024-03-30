using System;
using System.Collections.Generic;

namespace Laphed.ScenariosUI.SingleActions
{
    public class SingleActionsExecutor
    {
        private class ConditionActionPair
        {
            public IResettableCondition condition;
            public Action action;
        }

        private readonly Dictionary<object, List<ConditionActionPair>> actionsMap = new();

        public void Execute()
        {
            bool actionInvoked = false;
            
            foreach (var kv in actionsMap)
            {
                foreach (ConditionActionPair conditionActionPair in kv.Value)
                {
                    if (actionInvoked)
                    {
                        conditionActionPair.condition.Reset();
                        continue;
                    }
                    
                    if (!conditionActionPair.condition.IsMet)
                    {
                        continue;
                    }

                    conditionActionPair.condition.Reset();
                    conditionActionPair.action.Invoke();
                    actionInvoked = true;
                }
            }
        }

        public SingleActionsExecutor AddAction(object actionProvider, IResettableCondition condition, Action action)
        {
            if (!actionsMap.ContainsKey(actionProvider))
            {
                actionsMap.Add(actionProvider, new List<ConditionActionPair>());
            }
            
            actionsMap[actionProvider].Add(new ConditionActionPair
            {
                condition = condition,
                action = action
            });
            
            return this;
        }

        public void ForgetActionsProvider(object actionProvider)
        {
            actionsMap.Remove(actionProvider);
        }
    }
}
