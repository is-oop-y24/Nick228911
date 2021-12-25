using System;
using System.Collections.Generic;
using System.Linq;

namespace Banks.PercentRestModel
{
    public class BalanceRangePercentRest : IPercentRest
    {
        private List<(decimal, double)> ranges;

        public BalanceRangePercentRest(List<(decimal, double)> ranges)
        {
            this.ranges = ranges;
        }

        public double CalcPercent(Account account)
        {
            (decimal, double) range = ranges.FirstOrDefault(t => t.Item1 > account.Balance);
            if (range.Item1 != 0)
                return range.Item2;
            return ranges.Last().Item2;
        }
    }
}
