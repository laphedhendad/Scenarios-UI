using System;
using System.Collections;
using System.Collections.Generic;

namespace Laphed.ScenariosUI.SingleActions
{
    internal class ConditionActionPairs : IEnumerable<ConditionActionPairs.ConditionActionPair>
    {
        public struct ConditionActionPair
        {
            public IResettableCondition condition;
            public Action action;
        }
        
        private readonly ConditionActionPair[] pairs;
            
        public ConditionActionPairs(ConditionActionPair[] pairs) => this.pairs = pairs;

        public IEnumerator<ConditionActionPair> GetEnumerator() => new ConditionActionPairEnumerator(pairs);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        
        private class ConditionActionPairEnumerator : IEnumerator<ConditionActionPair>
        {
            private readonly ConditionActionPair[] pairs;
            private int position = -1;

            public ConditionActionPairEnumerator(ConditionActionPair[] pairs) => this.pairs = pairs;

            public ConditionActionPair Current
            {
                get
                {
                    if (position == -1 || position >= pairs.Length)
                    {
                        throw new IndexOutOfRangeException();
                    }

                    return pairs[position];
                }
            }

            object IEnumerator.Current => Current;

            public bool MoveNext()
            {
                if (position >= pairs.Length - 1)
                {
                    return false;
                }

                position++;
                return true;
            }

            public void Reset() => position = -1;

            public void Dispose() { }
        }
    }
}