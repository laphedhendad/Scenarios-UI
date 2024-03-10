using System;
using System.Collections.Generic;

namespace Laphed.ScenariosUI.SingleActions
{
    public class SingleActionsExecutorBuilder
    {
        internal readonly List<ConditionActionPairs.ConditionActionPair> conditionActionPairs;

        public SingleActionsExecutor Build()
        {
            return new SingleActionsExecutor(conditionActionPairs.ToArray());
        }
    }

    public static class SingleActionsExecutorBuilderExtensions
    {
        public static SingleActionsExecutorBuilder WithAction(this SingleActionsExecutorBuilder builder,
            IResettableCondition condition, Action action)
        {
            builder.conditionActionPairs.Add(
                new ConditionActionPairs.ConditionActionPair
                {
                    condition = condition,
                    action = action
                }
            );

            return builder;
        }
    }
}
