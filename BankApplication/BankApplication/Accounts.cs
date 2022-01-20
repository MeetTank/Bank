using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication
{
    public class Accounts
    {
        private Guid account_no = Guid.NewGuid();

        private char account_type;
        private int balance = 1000;

        private DateTime hourlimit;
        private int transtotal = 0;

        Random random = new Random();

        private List<string> alltransaction = new List<string>();

        private DateTime debithourlimit;
        private int totaldebited = 0;

        public Guid Account_No { get { return account_no; } }
        public Accounts(char account_type) { this.account_type = account_type; }
        public char AccountType { get { return account_type; } }
        public int Balance { get { return balance; } }

        public void Credit(int amount)
        {

            int transaction_id = random.Next();
            if (amount % 100 != 0)
            {
                Console.WriteLine("   Amount should be in multiple(s) of 100");
                return;
            }

            if (transtotal == 0)
            {
                hourlimit = DateTime.Now;
            }
                

            if (transtotal == 4)
            {
                if (DateTime.Now.Subtract(hourlimit).TotalSeconds < 60)
                {
                    Console.WriteLine("   Hourly transaction limit crossed");
                    return;
                }
                else
                {
                    transtotal = 0;
                    hourlimit = DateTime.Now;
                }
            }
            transtotal++;
            balance += amount;
            alltransaction.Add($"{transaction_id}\t{amount}\t{"Credit"}\t{DateTime.Now}");
            Console.WriteLine($"   Account Credited with {amount},Current Balance {balance}.");

        }

        public void Debit(int amount)
        {
            int transaction_id = random.Next();
            if (amount % 100 != 0)
            {
                Console.WriteLine("   Amount should be in multiple(s) of 100");
                return;
            }
            if (amount > 50000)
            {
                Console.WriteLine("   Debit amount should be less then 50,000.");
                return;
            }
            if (amount > balance)
            {
                Console.WriteLine("   Not sufficient balance");
                return;
            }
            if(amount > 30000)
            {
                Console.WriteLine("   Rs.30 will be debited as service charge.");
                amount += 30;
            }

            if (transtotal == 0)
            {
                hourlimit = DateTime.Now;
            }
            if (totaldebited == 0)
            {
                debithourlimit = DateTime.Now;
            }

            if (transtotal == 4)
            {
                if (DateTime.Now.Subtract(hourlimit).TotalSeconds < 60)
                {
                    Console.WriteLine("   Hourly transaction limit crossed");
                    return;
                }
                else
                {
                    transtotal = 0;
                    hourlimit = DateTime.Now;


                }
            }

            if (totaldebited + amount > 200000)
            {
                if ((DateTime.Now.Subtract(debithourlimit).TotalSeconds) < 60)
                {
                    Console.WriteLine("   Crossed maximum hour limit , try after sometime.");
                    return;
                }
                else
                {
                    totaldebited = 0;
                    debithourlimit = DateTime.Now;
                    
                        
                 }
            }


                balance -= amount;
                totaldebited += amount;
                transtotal++;
                alltransaction.Add($"{transaction_id}\t{amount}\t{"Debit"}\t{DateTime.Now}");
                if (amount > 30000)
                    Console.WriteLine($"   Account is Debited with {amount - 30}, updated balance is {balance}.");
                else
                    Console.WriteLine($"   Account is Debited with {amount}, updated balance is {balance}.");
     
        }


        public void showBalance()
        {
            Console.WriteLine($"   Account number : {account_no} , Balance : {balance}");
        }

        public void BankStatement()
        {
            Console.WriteLine($"ID\t\tAmount\tOperation\tTime");
            foreach (var transaction in alltransaction)
            {
                Console.WriteLine($"  {transaction}");
            }
        }




    }

}
