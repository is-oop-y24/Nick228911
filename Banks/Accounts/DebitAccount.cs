using System;
using System.Collections.Generic;
using System.Text;

namespace Banks
{
    public class DebitAccount : Account
    {
        public DebitAccount(string number, Client client, Bank bank, decimal balance = 0)
            : base(number, client, bank, balance)
        {
        }

        public override double CalcPercentRest()
        {
            return Bank.DebitPercentRest.CalcPercent(this);
        }

        public override void Withdraw(decimal money)
        {
            if (money > Balance)
                throw new ArgumentException("Недостаточно средств");

            base.Withdraw(money);
        }
    }
}
