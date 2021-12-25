using System;
using System.Collections.Generic;
using System.Text;

namespace Banks.Transactions
{
    public abstract class BaseTransaction
    {
        public BaseTransaction(decimal sum, Account account)
        {
            Sum = sum;
            Account = account;
        }

        public decimal Sum { get; }
        public Account Account { get; }

        public abstract void Execute();
        public abstract void Undo();
    }
}
