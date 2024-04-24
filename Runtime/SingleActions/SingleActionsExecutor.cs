using System;
using Cysharp.Threading.Tasks;

namespace Laphed.ScenariosUI.SingleActions
{
    public class SingleActionsExecutor
    {
        private readonly ConditionActionPairs conditionActionPairs;

        internal SingleActionsExecutor(ConditionActionPairs conditionActionPairs)
        {
            this.conditionActionPairs = conditionActionPairs;
        }
        
        public UniTask Execute()
        {
            UniTask result = UniTask.CompletedTask;
            
            using var enumerator = conditionActionPairs.GetEnumerator();

            while (enumerator.MoveNext())
            {
                ConditionActionPairs.ConditionActionPair conditionActionPair = enumerator.Current;

                if (!conditionActionPair.condition.IsMet)
                {
                    continue;
                }
                
                conditionActionPair.condition.Reset();

                switch (conditionActionPair.action)
                {
                    case VoidAction voidAction:
                        voidAction.Invoke();
                        break;
                    
                    case TaskAction taskAction:
                        result = taskAction.Task.Invoke();
                        break;
                    
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                break;
            }

            while (enumerator.MoveNext())
            {
                enumerator.Current.condition.Reset();
            }

            return result;
        }
    }
}
