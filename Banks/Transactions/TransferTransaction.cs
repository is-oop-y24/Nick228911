using System;
using System.Collections.Generic;
using System.Text;

namespace Banks.Transactions
{
    public class TransferTransaction : BaseTransaction
    {
        private Account accountTo;

        public TransferTransaction(decimal sum, Account accountFrom, Account accountTo)
            : base(sum, accountFrom)
        {
            this.accountTo = accountTo;
        }

        public override void Execute()
        {
            Account.Withdraw(Sum);
            accountTo.Refill(Sum);
        }

        public override void Undo()
        {
            accountTo.Withdraw(Sum);
            Account.Refill(Sum);
        }
    }
}
