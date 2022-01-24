using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication
{
    public class BankOperation
    {
        private Dictionary<Accounts,Customer> accounts = new Dictionary<Accounts, Customer>();

        public Dictionary<Accounts, Customer> Accounts { get { return accounts; } }



        public Customer CreateCustomer(char accounttype)
        {
            var customer = new Customer();
            var account = new Accounts(accounttype);
            accounts.Add(account, customer);
            Console.WriteLine($" customer id : {customer.Customer_Id} and A/C number : {account.Account_No}");
            return customer;
        }

        public void CreateAnotherAccount(char accounttype,Customer customer)
        {
            var account = new Accounts(accounttype);
            accounts.Add(account, customer);
            Console.WriteLine($" customer id : {customer.Customer_Id} and A/C number : {account.Account_No}");

        }

        public Customer SearchCustomer(string cId)
        {
            foreach (var customer in accounts.Values)
            {
                if (customer.Customer_Id.ToString().Equals(cId))
                    return customer;
            }
            throw new Exception("   Customer not found please add correct detials.");
        }

        public Accounts SearchAccount(string accNo)
        {
            foreach (var account in accounts.Keys)
            {
                if (account.Account_No.ToString().Equals(accNo))
                    return account;
            }
            throw new Exception("   Account not found please add correct details.");

        }

        public void DisplayBalance(string c_id)
        {
            var result = from record in accounts
                         where record.Value.Customer_Id.ToString() == c_id
                         select (record.Key);

            if (result.Count() == 0)
                throw new Exception("   Please Enter correct CustomerId");

            foreach (var account in result)
            {
                Console.WriteLine($"   A/C No : {account.Account_No} , Balance : {account.Balance}.");
            }
        }


    }
}
