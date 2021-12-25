using System;
using System.Collections.Generic;
using System.Text;

namespace Banks.PercentRestModel
{
    public class NullPersentRest : IPercentRest
    {
        public double CalcPercent(Account account)
        {
            return 0;
        }
    }
}
