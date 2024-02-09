using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BankAccountNS;
using Bank;


namespace BankTests
{
    [TestClass] //mandatory for testing

    /*A test method must meet the following requirements:

    It's decorated with the [TestMethod] attribute.

    It returns void.

    It cannot have parameters.
*/
    public class UnitTest1
    {

        [TestMethod]
     

        public void funktionaalinenTesti()
        {

            double beginningBalance = 110.99;
            string accountN = "5756";
            BankAccount account = new BankAccount(accountN, beginningBalance);
            string Name = "Henry Ford";
           Customer.NewCustomerOrAccountToList(Name, accountN);

            double beginningBalance2 = 11.99;
            string accountN2 = "5558";
            BankAccount account2 = new BankAccount(accountN2, beginningBalance2);
            string Name2 = "Henry Ford";
           Customer.NewCustomerOrAccountToList(Name2, accountN2);

            double beginningBalance3 = 11.99;
            string accountN3 = "7777";
            BankAccount account3 = new BankAccount(accountN3, beginningBalance3);
            string Name3 = "Suzie Kang";
             Customer.NewCustomerOrAccountToList(Name3, accountN3);

            //Henry haluaa tallettaa rahaa tililleen
            BankAccount Baccount = BankAccount.GetAccountObjectByAccountNumber(accountN2); //etsitään tiliolio     // Console.WriteLine($"B account {Baccount.AccountNumber} {Baccount.m_balance}");
                        Baccount.Credit(100); //tallennetaan satku

           BankAccount.SiirraRahaa(accountN2, accountN3, 50); //Henry siirtää 5 kybää Suzielle

           
        }


        [TestMethod]
        public void Debit_WithValidAmount_UpdatesBalance()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;

            string accountN = "5256";
            BankAccount account = new BankAccount(accountN, beginningBalance);
            string Name = "Henry Ford";
            Customer.NewCustomerOrAccountToList(Name, accountN);

            // Act
            account.Debit(debitAmount);

            // Assert
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");


            
        }
        [TestMethod]
      
        public void SiirräRahaaTest()
        {

            double beginningBalance = 110.99;
            string accountN = "5756";
            BankAccount account = new BankAccount(accountN, beginningBalance);
            string Name = "Henry Ford";
            Customer.NewCustomerOrAccountToList(Name, accountN);

            double beginningBalance2 = 11.99;
            string accountN2 = "5558";
            BankAccount account2 = new BankAccount(accountN2, beginningBalance2);
            string Name2 = "Henry Ford";
            Customer.NewCustomerOrAccountToList(Name2, accountN2);

          BankAccount.SiirraRahaa("5756","5558",50);

      
                
            


        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SiirräRahaaTestLiianIsoSumma()
        {

            double beginningBalance = 110.99;
            string accountN = "5756";
            BankAccount account = new BankAccount(accountN, beginningBalance);
            string Name = "Henry Ford";
            Customer.NewCustomerOrAccountToList(Name, accountN);

            double beginningBalance2 = 11.99;
            string accountN2 = "5558";
            BankAccount account2 = new BankAccount(accountN2, beginningBalance2);
            string Name2 = "Henry Ford";
            Customer.NewCustomerOrAccountToList(Name2, accountN2);
             BankAccount.SiirraRahaa("5756", "5558", 150);
          
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SiirräRahaaTestNegatiivinenSumma()
        {

            double beginningBalance = 110.99;
            string accountN = "5756";
            BankAccount account = new BankAccount(accountN, beginningBalance);
            string Name = "Henry Ford";
            Customer.NewCustomerOrAccountToList(Name, accountN);

            double beginningBalance2 = 11.99;
            string accountN2 = "5558";
            BankAccount account2 = new BankAccount(accountN2, beginningBalance2);
            string Name2 = "Henry Ford";
            Customer.NewCustomerOrAccountToList(Name2, accountN2);

           BankAccount.SiirraRahaa("5756", "5558", -50);
            
        }

        [TestMethod]
        public void Withdraw_ValidAmount_ChangesBalance()
        {
            // arrange
            double currentBalance = 10.0;
            double withdrawal = 1.0;
            double expected = 9.0;
            string accountN = "5256";
            BankAccount account = new BankAccount(accountN, currentBalance);
            string Name = "Henry Ford";
            Customer.NewCustomerOrAccountToList(Name, accountN);

            // act
            account.Debit(withdrawal);

            // assert
            Assert.AreEqual(expected, account.Balance);
        }

        [TestMethod]

        public void Withdraw_AmountMoreThanBalance_Throws()
        {
            // arrange
            double beginningBalance = 11.99;
            string accountN = "5256";
            BankAccount account = new BankAccount(accountN, beginningBalance);
            string Name = "Henry Ford";
            Customer.NewCustomerOrAccountToList(Name, accountN);

            // act and assert
            var exception = Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => account.Debit(20.0));
            Assert.AreEqual("Debit amount exceeds balance (Parameter 'amount')\r\nActual value was 20.", exception.Message);
        }
        [TestMethod]
        public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = -100.00;
            string accountN = "5256";
            BankAccount account = new BankAccount(accountN, beginningBalance);
            string Name = "Henry Ford";
            Customer.NewCustomerOrAccountToList(Name, accountN);

            // Act and assert
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => account.Debit(debitAmount));
        }
        [TestMethod]
        public void Credit_ShouldThrowArgumentOutOfRange()//under 0
        {
            // Arrange
            double beginningBalance = 11.99;
            double creditAmount = -100.00;
            string accountN = "5256";
            BankAccount account = new BankAccount(accountN, beginningBalance);
            string Name = "Henry Ford";
            Customer.NewCustomerOrAccountToList(Name, accountN);

            // Act and assert

            var exception= Assert.ThrowsException<Exception>(() => account.Credit(creditAmount));
            Assert.AreEqual("Credit is less than zero",exception.Message);
         
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = 20.0;
            string accountN = "5256";
            BankAccount account = new BankAccount(accountN, beginningBalance);
            string Name = "Henry Ford";
            Customer.NewCustomerOrAccountToList(Name, accountN);

            account.Debit(debitAmount);

          
        }

        [TestMethod]
    
        public void AddNewAccountsWithCorrectData()
        {
           

            double beginningBalance2 = 11.99;
            string accountN2 = "5555";
            BankAccount account2 = new BankAccount(accountN2, beginningBalance2);
            string Name2 = "Henry Ford";
            Customer.NewCustomerOrAccountToList(Name2, accountN2);


        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddNewAccountsWithWrongData()
        {
            
            string accountN2 = "SILLI";
          // BankAccount account2 = new BankAccount(accountN2, beginningBalance2);
            string Name2 = "Henry Ford";
           Customer.NewCustomerOrAccountToList(Name2, accountN2);


        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TryRemoveNonExistingAccount()
        {
            double beginningBalance = 11.99;
            string accountN = "5256";
            BankAccount account = new BankAccount(accountN, beginningBalance);
            string Name = "Henry Ford";
            Customer.NewCustomerOrAccountToList(Name, accountN);

            double beginningBalance2 = 11.99;
            string accountN2 = "5555";
            BankAccount account2 = new BankAccount(accountN2, beginningBalance2);
            string Name2 = "Henry Ford";
            Customer.NewCustomerOrAccountToList(Name2, accountN2);

            double beginningBalance3 = 99.99;
            string accountN3 = "1111";
            BankAccount account3 = new BankAccount(accountN3, beginningBalance3);
            string Name3 = "Jacob Minn";
            Customer.NewCustomerOrAccountToList(Name3, accountN3);

            double beginningBalance4 = 56.99;
            string accountN4 = "2222";
            BankAccount account4 = new BankAccount(accountN4, beginningBalance4);
            string Name4 = "Jacob Minn";
            Customer.NewCustomerOrAccountToList(Name4, accountN4);

            Customer.RemoveAccountFromCustomer(Name, accountN4);

            

        }
    }
}
