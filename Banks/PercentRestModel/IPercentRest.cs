using System;
using System.Collections.Generic;
using System.Text;

namespace Banks.PercentRestModel
{
    public interface IPercentRest
    {
        double CalcPercent(Account account);
    }
}
