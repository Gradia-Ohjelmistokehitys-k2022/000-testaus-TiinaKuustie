using Bank;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Security.Principal;

namespace BankAccountNS
{
    /// <summary>
    /// Bank account demo class.
    /// </summary>
    public class BankAccount
    {
        public readonly string AccountNumber; //tallennan stringinä ni ei oo vahingossa mahdollsta tehdä laskutoimituksia tähän
        public double m_balance;
        public const string DebitAmountExceedsBalanceMessage = "Debit amount exceeds balance";
        public const string DebitAmountLessThanZeroMessage = "Debit amount is less than zero";
        private BankAccount() { }
        public static List<BankAccount> BankAccounts = new List<BankAccount>();

        public BankAccount(string accountNumber, double balance)
        {
            AccountNumber = accountNumber;
            m_balance = balance;
            BankAccounts.Add(this);
        }

        public string AccountNum //palautti ennen asiakkaan nimen, nyt meil on täällä vaan tilinumeroja
        {
            get { return AccountNumber; }
        }

        public double Balance
        {
            get { return m_balance; }
        }
        public static bool SiirraRahaa(string Ltili, string Ktili, double siirtoSumma)
        {
            BankAccount lahtotili = BankAccounts.Find(obj => obj.AccountNumber == Ltili);
            BankAccount kohdetili = BankAccounts.Find(obj => obj.AccountNumber == Ktili);

            double alkuLahtotili = lahtotili.Balance;
            double alkuKohdetili = kohdetili.Balance;

            if (siirtoSumma > alkuLahtotili || siirtoSumma < 0)
            {
                Console.WriteLine("Invalid transfer amount");
                throw new System.ArgumentException("Invalid transfer amount");
               // return false;
            }
            else
            {

                lahtotili.Debit(siirtoSumma);
                kohdetili.Credit(siirtoSumma);

                double loppuLahtotili = lahtotili.Balance;
                double loppuKohdetili = kohdetili.Balance;

                if ((loppuLahtotili == (alkuLahtotili - siirtoSumma)) && (loppuKohdetili == (alkuKohdetili + siirtoSumma))) { return true; }
                else { return false; }
            }


        }
        public void Debit(double amount)
        {
            if (amount > m_balance)
            {
                throw new System.ArgumentOutOfRangeException("amount", amount, DebitAmountExceedsBalanceMessage);
            }

            if (amount < 0)
            {
                throw new System.ArgumentOutOfRangeException("amount", amount, DebitAmountLessThanZeroMessage);
            }

            m_balance -= amount; // intentionally incorrect code, korjattu
        }

        public void Credit(double amount)
        {
            if (amount < 0)
            {
                throw new Exception("Credit is less than zero");

            }

            m_balance += amount;
         
        }

        public static BankAccount GetAccountObjectByAccountNumber(string accountN)
        {
            BankAccount foundObject = BankAccounts.Find(obj => obj.AccountNumber == accountN);
            if ( foundObject != null)
            {
                return foundObject;
            }
           else { throw new System.ArgumentException("No account found"); }
        }

        public static void Main()
        {
          
        }
    }
}