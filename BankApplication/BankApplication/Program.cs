using System;

namespace BankApplication
{
    class program
    {

        static void Main(string[] args)
        {
            CreateData();  
            int choice;
            do
            {
             choice = showMenu();
                switch (choice)
                {
                    case 0:
                        Console.WriteLine("Thank you for visiting!");
                        break;

                    case 1:
                        choice1();
                        break;

                    case 2:
                        choice2();
                        break;
                    case 3:
                        choice3();
                        break;

                    case 4:
                        choice4();
                        break;

                    case 5:
                        choice5();  
                        break;

                    default:
                        Console.WriteLine("Choose Correct option!");
                        break;

                }

            } while (choice != 0);
               
        }
        private static BankOperation bankOperation = new BankOperation();

        private static int showMenu()
        {
         
            Console.WriteLine("\n  1 ==> Credit using account number");
            Console.WriteLine("  2 ==> Debit using account number");
            Console.WriteLine("  3 ==> Display balance using account number");
            Console.WriteLine("  4 ==> Display balance for all the accounts using Customer Id");
            Console.WriteLine("  5 ==> Display account statement using Account Number");
            Console.WriteLine("  0 ==> Exit!");

            Console.Write("\n\tEnter your choice: ");
            int choice =    Convert.ToInt32(Console.ReadLine());
            return choice;
        }

        private static void CreateData()
        {
            var newcustomer = bankOperation.CreateCustomer('S');

            
            bankOperation.CreateAnotherAccount('C', newcustomer);
            
            newcustomer = bankOperation.CreateCustomer('C');
            bankOperation.CreateAnotherAccount('C',newcustomer);
            bankOperation.CreateAnotherAccount('C', newcustomer);

            
            newcustomer = bankOperation.CreateCustomer('C');
            bankOperation.CreateAnotherAccount('C', newcustomer);
            bankOperation.CreateAnotherAccount('S', newcustomer);
            bankOperation.CreateAnotherAccount('S', newcustomer);
            bankOperation.CreateAnotherAccount('C', newcustomer);
            Console.WriteLine("\n\n");
        }

        private static void choice1()
        {
            Console.Write("\tEnter Account Number: ");
            string acc_no = Console.ReadLine();
            Console.Write("\tEnter Amount: ");
            int val = Convert.ToInt32(Console.ReadLine());
            try
            {
                bankOperation.SearchAccount(acc_no).Credit(val);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void choice2()
        {
            Console.Write("\tEnter Account Number: ");
            string acc_no = Console.ReadLine();
            Console.Write("\tEnter Amount: ");
            int val = Convert.ToInt32(Console.ReadLine());
            try
            {
                bankOperation.SearchAccount(acc_no).Debit(val);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private static void choice3()
        {
            Console.Write("\tEnter Account Number: ");
            string c_id = Console.ReadLine();
            try
            {
                bankOperation.SearchAccount(c_id).showBalance();
            }
            catch(Exception ex)
            {
                Console.Write(ex.Message);
            }

        }

        private static void choice4()
        {
            Console.Write("\tEnter customer-Id: ");
            string c_id = Console.ReadLine();
            try
            {
                bankOperation.DisplayBalance(c_id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void choice5()
        {
            Console.Write("\tEnter A/C no : ");
            var acc_no = Console.ReadLine();
            try
            {
                bankOperation.SearchAccount(acc_no).BankStatement();
            
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);

            }



        }

       




    }
    
   
}