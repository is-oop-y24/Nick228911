using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Banks
{
    public class CentralBank
    {
        private List<Bank> banks = new List<Bank>();

        public void CreateBank(string name)
        {
            banks.Add(new Bank(name));
        }

        public void AddBank(Bank bank)
        {
            banks.Add(bank);
        }

        public Bank FindBank(string name)
        {
            return banks.FirstOrDefault(t => t.Name == name);
        }

        public void RefillRestPercentSum()
        {
            banks.ForEach(t => t.RefillRestPercentSum());
        }

        public void WithdrawComission()
        {
            banks.ForEach(t => t.WithdrawComission());
        }
    }
}
