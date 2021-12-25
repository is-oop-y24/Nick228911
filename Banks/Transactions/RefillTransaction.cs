using System;
using System.Collections.Generic;
using System.Text;

namespace Banks.Transactions
{
    public class RefillTransaction : BaseTransaction
    {
        public RefillTransaction(decimal sum, Account account)
            : base(sum, account)
        {
        }

        public override void Execute()
        {
            Account.Balance += Sum;
        }

        public override void Undo()
        {
            Account.Balance -= Sum;
        }
    }
}
