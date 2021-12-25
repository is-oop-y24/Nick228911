using System;
using System.Collections.Generic;
using System.Text;
using Banks.Transactions;

namespace Banks
{
    public abstract class Account
    {
        private Client client;
        private string number;
        private List<BaseTransaction> transactions = new List<BaseTransaction>();
        private decimal sumPercentRest;

        public Account(string number, Client client, Bank bank, decimal balance = 0)
        {
            this.client = client;
            this.number = number;
            Balance = balance;
            Bank = bank;
        }

        public Bank Bank { get; }

        public decimal Balance { get; set; }

        public string Number => number;

        public Client Client => client;

        public bool IsChecked { get; set; }

        public virtual void Withdraw(decimal money)
        {
            if (!IsChecked && money > Bank.SumLimit)
                throw new ArgumentException($"Ваш счет является сомнительным. Нельзя снять сумму больше чем {Bank.SumLimit}");

            var transaction = new WithdrawTransaction(money, this);
            transaction.Execute();

            transactions.Add(transaction);
        }

        public void Refill(decimal money)
        {
            var transaction = new RefillTransaction(money, this);
            transaction.Execute();

            transactions.Add(transaction);
        }

        public void Transfer(Account other, decimal money)
        {
            var transaction = new TransferTransaction(money, this, other);
            transaction.Execute();

            transactions.Add(transaction);
        }

        public void CancelTransaction(int number)
        {
            transactions[number].Undo();
            transactions.RemoveAt(number);
        }

        public abstract double CalcPercentRest();

        public void CalcSumRest()
        {
            sumPercentRest += Balance * (decimal)CalcPercentRest() / 100;
        }

        public void AddSumRest()
        {
            Balance += sumPercentRest;
            sumPercentRest = 0;
        }

        public virtual void WithdrawComission()
        {
        }
    }
}
