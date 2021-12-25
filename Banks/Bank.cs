using System;
using System.Collections.Generic;
using System.Linq;
using Banks.PercentRestModel;

namespace Banks
{
    public class Bank
    {
        private string name;
        private List<Client> clients = new List<Client>();
        private List<Account> accounts = new List<Account>();
        private decimal sumLimit;

        public Bank(string name)
        {
            this.name = name;
        }

        public event Action<decimal> ChangeSumLimit;

        public string Name => name;
        public decimal SumLimit
        {
            get
            {
                return sumLimit;
            }
            set
            {
                sumLimit = value;
                ChangeSumLimit?.Invoke(sumLimit);
            }
        }

        public IPercentRest CreditPercentRest { get; set; }
        public IPercentRest DebitPercentRest { get; set; }
        public IPercentRest DepositPercentRest { get; set; }
        public double Comission { get; set; }

        public void AddAccount(Account account, Client client)
        {
            accounts.Add(account);
            client.AddAccount(account);
        }

        public void AddClient(Client client)
        {
            clients.Add(client);
        }

        public void RefillRestPercentSum()
        {
            accounts.ForEach(t => t.AddSumRest());
        }

        public void WithdrawComission()
        {
            accounts.ForEach(t => t.WithdrawComission());
        }

        public Client FindClient(string name, string surname)
        {
            return clients.FirstOrDefault(t => t.Name == name && t.Surname == surname);
        }

        public string GenerateNumber()
        {
            var random = new Random();
            string number = string.Empty;
            while (true)
            {
                for (int i = 0; i < 20; i++)
                {
                    number += random.Next(10);
                }

                if (accounts.Any(t => t.Number == number))
                    number = string.Empty;
                else
                    break;
            }

            return number;
        }
    }
}
