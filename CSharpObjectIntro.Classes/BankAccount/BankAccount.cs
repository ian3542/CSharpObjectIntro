using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CSharpObjectIntro.Classes.BankAccount
{
    public class BankAccount
    {
        // As you complete each task make sure you test your code carefully
        // Choose some combination of manual testing, Debug.Assert and unit tests

        // Task One        
        // The bank account should have a balance property        
        // It should have a constructor that sets the initial balance (default zero) and the opening date (default today)
        // It should have methods to deposit and withdraw/make payments from the account. 
        public BankAccount(double balance)
        {   
            Balance = balance;
            OpeningDate = DateTime.Now;
            Overdraft = 0;
            Transactions = new List<AccountTransaction>();
        }
        public double Balance { get; private set; }
        public DateTime OpeningDate { get; private set; }
        public double Overdraft { get; private set; }
        public List<AccountTransaction> Transactions { get; private set; }


        public double deposit(double amount,string category, string counterparty, string description)
        {
            Balance += amount;
            AccountTransaction newTransaction = new AccountTransaction(DateTime.Now, amount, Balance, category, counterparty, "deposit", description);
            Transactions.Add(newTransaction);
            return Balance;
        }
        public double withdraw(double amount, string category, string counterparty, string description)
        {
            if (Balance - amount > -1 * Overdraft)
            {
                Balance -= amount;
                AccountTransaction newTransaction = new AccountTransaction(DateTime.Now, amount, Balance, category, counterparty, "withdraw", description);
                Transactions.Add(newTransaction);
                return Balance;
            }
            else
            {
                Console.WriteLine("overdraft limit exceeded");
                return Balance;
            }
        }
        // Task Two
        // Give the option to set an overdraft limit
        // Do not allow a withdrawal/payment if the overdraft limit is exceeded. You could return false or throw an exception.
        public double overdraft(double amount)
        {
            Overdraft = amount;
            return Overdraft;
        }
        // Task Three
        // Create a new class called AccountTransaction.
        // It could contain properties such as
        // date, amount, category, counterparty, transactionType, description (optional)
        // e.g 26/09/2022 16:45, -300, Groceries, Waitrose, Card, Weekly shop
        //     27/09/2022 17:40, 200, Gift, Bob Smith, Cheque, Birthday present
        // You might wish to use enums for category and transactionType
        // Amend your bank account to contain a list of transactions
        // The methods for deposit and withdraw/make payments should be amended to add transactions

        // Task Four
        // Now add some new methods to your account
        // - See what the balance was at a previous date
        // - See how much money was spent in a given time period
        // - See how much money was spent in different categories
        public double prevBalance(DateTime date)
        {
            double dayBalance = 0;
            for (int i = Transactions.Count-1; i > 0; i--)
            {
                if (Transactions[i].Date.DayOfYear == date.DayOfYear)
                {
                    dayBalance = Transactions[i].NewBalance;
                }
            }
            return dayBalance;
        }

        public double spendingOverTime(DateTime start, DateTime end)
        {
            double amount = 0;
            for (int i=0; i<Transactions.Count;i++)
            {
                if (Transactions[i].Date >= start && Transactions[i].Date <= end && Transactions[i].TransactionType == "withdraw")
                {
                    amount += Transactions[i].Amount;
                }
            }
            return amount;
        }

        public double spendingCategory(string category)
        {
            double amount = 0;
            for (int i = 0; i < Transactions.Count; i++)
            {
                if (Transactions[i].Category == category && Transactions[i].TransactionType == "withdraw")
                {
                    amount += Transactions[i].Amount;
                }
            }
            return amount;
        }


        // Extension
        // Work out how much interest is payable on your account
        // For the moment make up the interest rates, though later we could look at loading them from a website
        // The interest should be added as transactions to your account
        public double interestPayment(double rate)
        {
            double payment = Balance * rate - Balance;
            deposit(payment,"interest","bank","annual interest payment");
            return payment;
        }




    }
}
