using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Text.RegularExpressions;

namespace Bank
{
   public class Customer
    {
       public string m_customerName {  get; set; }
        public List<string> OneCustomersAccounts { get; set; }

        public static List<Customer>? AllAccounts = new List<Customer>();



        public Customer(string Name, string AccountN) //luodaan ihan tuliterä asiakas
        {
            m_customerName = Name;
            OneCustomersAccounts = new List<string> { AccountN };
           
        }
        public static void NewCustomerOrAccountToList(string Name, string accountN)
        {
            if (Regex.IsMatch(accountN, @"^[0-9]+$") == false)
            {
                Console.WriteLine("Invalid input, no letters allowed on account number");
                throw new ArgumentException("Invalid input, no letters allowed on account number");
            }

            Customer foundObject = AllAccounts.Find(obj => obj.m_customerName == Name);

            if (foundObject == null) //if customer does not exist, create a new customer and account
            {
                Customer customerx = new Customer(Name, accountN);
                AllAccounts.Add(customerx);
             

                if (AllAccounts.Contains(customerx) == true)
                {
                    Console.WriteLine($"Added a new customer {customerx.m_customerName} with bank account {accountN}.");
                  
                }
                else
                {
                    Console.WriteLine("Adding the customer failed");
                    throw new ArgumentException("Adding the customer failed");
                }


            }
            else //if customer does already exist, add the account number to their list
            {
                foundObject.OneCustomersAccounts.Add(accountN);


                if (foundObject.OneCustomersAccounts.Contains(accountN) == true)
                {
                    Console.WriteLine($"List inside {foundObject.m_customerName} modified to include {accountN}.");
                  
                }
                else 
                {
                    Console.WriteLine("Adding the account failed");
                    throw new ArgumentException("Adding the account failed");
                }  

               /* 
                foreach(string account in foundObject.OneCustomersAccounts)
                {
                    Console.WriteLine(account);
                }*/
            }
        }//  public static void NewCustomerOrAccountToList(string Name, string accountN) end

        public static void RemoveAccountFromCustomer(string Name, string accountN)
        {
            if (Regex.IsMatch(accountN, @"^[0-9]+$") == false) 
            {
                Console.WriteLine("Invalid input, no letters allowed on account number");
                throw new ArgumentException("Invalid input, no letters allowed on account number");
            }
            Customer foundObject = AllAccounts.Find(obj => obj.m_customerName == Name);
            if (foundObject == null) 
            {
                Console.WriteLine("Specified customer does not exist");
                throw new ArgumentException("Specified customer does not exist");
                //  throw new Exception("Specified customer does not exist");
            }
            else
            {
                if (foundObject.OneCustomersAccounts.Contains(accountN) == true)
                {
                    Console.WriteLine($"Removed account {accountN} from the customer {foundObject.m_customerName}");

                    //täss kohtaa olis luonnollisesti sit tilin tyhjennys jne. toiminnot

                    foundObject.OneCustomersAccounts.Remove(accountN);

                    /*
                    foreach (string account in foundObject.OneCustomersAccounts)
                    {
                        Console.WriteLine(account);
                    }*/
                  
                } //true
                else
                {
                    Console.WriteLine("Account does not exist");
                    throw new ArgumentException("Account does not exist");
                
                }
            }
        }
    }



}
