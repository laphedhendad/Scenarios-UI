using System.Collections.Generic;

namespace Laphed.ScenariosUI.SingleActions
{
    public class SingleActionsExecutor
    {
        private readonly ConditionActionPairs conditionActionPairs;

        internal SingleActionsExecutor(ConditionActionPairs.ConditionActionPair[] conditionActionPairs)
        {
            this.conditionActionPairs = new ConditionActionPairs(conditionActionPairs);
        }

        public void Execute()
        {
            IEnumerator<ConditionActionPairs.ConditionActionPair> enumerator = conditionActionPairs.GetEnumerator();

            ConditionActionPairs.ConditionActionPair pair;

            while (enumerator.MoveNext())
            {
                pair = enumerator.Current;

                if (!pair.condition.IsMet)
                {
                    continue;
                }

                pair.condition.Reset();
                pair.action.Invoke();
            }

            while (enumerator.MoveNext())
            {
                pair = enumerator.Current;
                pair.condition.Reset();
            }

            enumerator.Dispose();
        }
    }
}
