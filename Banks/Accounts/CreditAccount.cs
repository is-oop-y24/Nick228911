using System;
using System.Collections.Generic;
using System.Text;

namespace Banks
{
    public class CreditAccount : Account
    {
        private decimal limit;

        public CreditAccount(string number, Client client, Bank bank, decimal balance = 0, decimal limit = 0)
            : base(number, client, bank, balance)
        {
            this.limit = limit;
        }

        public override double CalcPercentRest()
        {
            return Bank.CreditPercentRest.CalcPercent(this);
        }

        public override void Withdraw(decimal money)
        {
            if (Balance + limit < money)
                throw new ArgumentException("Недостаточно средств");

            base.Withdraw(money);
        }

        public override void WithdrawComission()
        {
            if (Balance < 0)
            {
                Balance -= Balance * (decimal)Bank.Comission / 100;
            }
        }
    }
}
