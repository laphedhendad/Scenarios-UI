using System;
using System.Collections;
using System.Collections.Generic;

namespace Laphed.ScenariosUI.SingleActions
{
    class ConditionActionPairs : IEnumerable<ConditionActionPairs.ConditionActionPair>
    {
        public struct ConditionActionPair
        {
            public IResettableCondition condition;
            public IAction action;
        }

        private class ConditionActionPairEnumerator : IEnumerator<ConditionActionPair>
        {
            public ConditionActionPair Current
            {
                get
                {
                    if (position == -1
                     || position >= pairs.Length)
                    {
                        throw new IndexOutOfRangeException();
                    }

                    return pairs[position];
                }
            }

            object IEnumerator.Current => Current;
            private readonly ConditionActionPair[] pairs;
            private int position = -1;

            public ConditionActionPairEnumerator(ConditionActionPair[] pairs)
            {
                this.pairs = pairs;
            }

            public void Dispose() { }

            public bool MoveNext()
            {
                if (position >= pairs.Length - 1)
                {
                    return false;
                }

                position++;
                return true;
            }

            public void Reset()
            {
                position = -1;
            }
        }

        private readonly ConditionActionPair[] pairs;

        public ConditionActionPairs(ConditionActionPair[] pairs)
        {
            this.pairs = pairs;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<ConditionActionPair> GetEnumerator()
        {
            return new ConditionActionPairEnumerator(pairs);
        }
    }
}
