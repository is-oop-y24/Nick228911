using System;
using System.Collections.Generic;
using Banks.PercentRestModel;

namespace Banks
{
    internal static class Program
    {
        private static Bank CreateBank()
        {
            Console.WriteLine("Введите название банка");
            string name = Console.ReadLine();
            var bank = new Bank(name);
            bank.CreditPercentRest = new NullPersentRest();
            bank.DebitPercentRest = new FixPercentRest(5);
            var ranges = new List<(decimal, double)>()
            {
                (50000, 3),
                (100000, 3.5),
                (100000, 4),
            };

            bank.DepositPercentRest = new BalanceRangePercentRest(ranges);
            Console.WriteLine("Введите комиссию");
            bank.Comission = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите лимит");
            bank.SumLimit = decimal.Parse(Console.ReadLine());

            return bank;
        }

        private static Client CreateClient()
        {
            Console.WriteLine("Введите имя клиента");
            string name = Console.ReadLine();
            Console.WriteLine("Введите фамилию клиента");
            string surname = Console.ReadLine();
            Console.WriteLine("Введите адрес клиента");
            string address = Console.ReadLine();
            Console.WriteLine("Введите пасспорт клиента");
            string passport = Console.ReadLine();

            var client = new Client(name, surname, address, passport);
            return client;
        }

        private static Account CreateAccount(Bank bank, Client client)
        {
            Console.WriteLine("1.Кредитный счет");
            Console.WriteLine("2.Депозитный счет");
            Console.WriteLine("3.Дебетовый счет");

            int type = int.Parse(Console.ReadLine());
            Account account = null;

            Console.WriteLine("Введите баланс: ");
            decimal balance = decimal.Parse(Console.ReadLine());

            switch (type)
            {
                case 1:
                    {
                        Console.WriteLine("Введите лимит: ");
                        decimal limit = decimal.Parse(Console.ReadLine());
                        account = new CreditAccount(bank.GenerateNumber(), client, bank, balance, limit);
                        break;
                    }

                case 2:
                    {
                        Console.WriteLine("Введите дату");
                        var date = DateTime.Parse(Console.ReadLine());
                        account = new DepositAccount(bank.GenerateNumber(), client, bank, date, balance);
                        break;
                    }

                case 3:
                    {
                        account = new DebitAccount(bank.GenerateNumber(), client, bank, balance);
                        break;
                    }
            }

            return account;
        }

        private static void ShowAccounts(Client client)
        {
            foreach (Account account in client.Accounts)
            {
                Console.WriteLine($"Номер: {account.Number}, Баланс = {account.Balance}");
            }
        }

        private static void Main()
        {
            var centralBank = new CentralBank();

            int choice;
            do
            {
                Console.WriteLine("1.Создать банк");
                Console.WriteLine("2.Создать клиента");
                Console.WriteLine("3.Создать счет");
                Console.WriteLine("4.Вывести счета клиента в заданном банке");

                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            Bank bank = CreateBank();
                            centralBank.AddBank(bank);
                            break;
                        }

                    case 2:
                        {
                            Console.WriteLine("Введите название банка клиента");
                            string name = Console.ReadLine();
                            Bank bank = centralBank.FindBank(name);
                            if (bank != null)
                            {
                                Client client = CreateClient();
                                bank.AddClient(client);
                            }

                            break;
                        }

                    case 3:
                        {
                            Console.WriteLine("Введите название банка клиента");
                            string name = Console.ReadLine();
                            Bank bank = centralBank.FindBank(name);
                            if (bank != null)
                            {
                                Console.WriteLine("Введите имя клиента");
                                string nameClient = Console.ReadLine();
                                Console.WriteLine("Введите фамилию клиента");
                                string surname = Console.ReadLine();

                                Client client = bank.FindClient(nameClient, surname);
                                if (client != null)
                                {
                                    Account account = CreateAccount(bank, client);
                                    bank.AddAccount(account, client);
                                }
                            }

                            break;
                        }

                    case 4:
                        {
                            Console.WriteLine("Введите название банка клиента");
                            string name = Console.ReadLine();
                            Bank bank = centralBank.FindBank(name);
                            if (bank != null)
                            {
                                Console.WriteLine("Введите имя клиента");
                                string nameClient = Console.ReadLine();
                                Console.WriteLine("Введите фамилию клиента");
                                string surname = Console.ReadLine();

                                Client client = bank.FindClient(nameClient, surname);
                                if (client != null)
                                {
                                    ShowAccounts(client);
                                }
                            }

                            break;
                        }
                }
            }
            while (choice != 0);
        }
    }
}
