using System;
using System.Collections.Generic;
using System.Text;

namespace Banks
{
    public class Client
    {
        private string name;
        private string surname;
        private string address;
        private string passport;
        private List<Account> accounts = new List<Account>();

        public Client(string name, string surname, string address = null, string passport = null)
        {
            this.name = name;
            this.surname = surname;
            this.address = address;
            this.passport = passport;
        }

        public string Name => name;
        public string Surname => surname;
        public List<Account> Accounts => accounts;

        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
                UpdateStatusAccounts();
            }
        }

        public string Passport
        {
            get
            {
                return passport;
            }
            set
            {
                passport = value;
                UpdateStatusAccounts();
            }
        }

        public bool IsChecked => !string.IsNullOrEmpty(address) && !string.IsNullOrEmpty(passport);

        public void AddAccount(Account account)
        {
            accounts.Add(account);
            account.IsChecked = IsChecked;
        }

        private void UpdateStatusAccounts()
        {
            accounts.ForEach(t => t.IsChecked = IsChecked);
        }
    }
}
