using System;
using System.Collections.Generic;
using System.Text;

namespace Banks
{
    public class DepositAccount : Account
    {
        private DateTime date;
        private double percentRest;

        public DepositAccount(string number, Client client, Bank bank, DateTime date, decimal balance = 0)
            : base(number, client, bank, balance)
        {
            this.date = date;
            percentRest = Bank.DepositPercentRest.CalcPercent(this);
        }

        public override double CalcPercentRest()
        {
            return percentRest;
        }

        public override void Withdraw(decimal money)
        {
            if (TimeManager.Instance.CurrentDate < date)
                throw new ArgumentException("Срок не закончился");
            if (money > Balance)
                throw new ArgumentException("Недостаточно средств");

            base.Withdraw(money);
        }
    }
}
