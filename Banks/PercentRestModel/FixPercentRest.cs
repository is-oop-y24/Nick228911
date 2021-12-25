using System;
using System.Collections.Generic;
using System.Text;

namespace Banks.PercentRestModel
{
    public class FixPercentRest : IPercentRest
    {
        private double percent;

        public FixPercentRest(double percent)
        {
            this.percent = percent;
        }

        public double CalcPercent(Account account)
        {
            return percent;
        }
    }
}
