using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpObjectIntro.Classes.Diary;
using CSharpObjectIntro.Classes.BankAccount;

namespace CSharpObjectIntro
{
    internal class OOPExercises
    {
        internal static void Run()
        {
            //UseDiary();
            UseBankAccount();
        }

        internal static void UseDiary()
        {
            // Create a new diary 
            Diary diary = new Diary("Bob Smith");

            // Add some events to your diary
            DateOnly x = new DateOnly(9, 12, 22);
            diary.AddEvent(x,20,"","",1,1);
            // Now check how many events you have on a particular day
            Console.WriteLine(diary.CheckDiary(x));
            // Implement a new method in the Diary class to return the number of morning events on a particular day
            // Call this method
            Console.WriteLine(diary.CheckMorningEvents(x));
        }

        internal static void UseBankAccount()
        {
            // Implement your bank account class following the instructions in the BankAccount class

            // Write calling code from here

            BankAccount account = new BankAccount(100);
            
            Console.WriteLine(account.deposit(50,"salary","employer","blank"));

            Console.WriteLine(account.withdraw(25,"food","tesco","blank"));

            Console.WriteLine(account.overdraft(100));

            //attempt to withdraw over the overdraft limit
            Console.WriteLine(account.withdraw(500, "phone", "iphone", "blank"));

            //withdraw within the overdraft limit
            Console.WriteLine(account.withdraw(150, "phone", "huawei", "blank"));

            Console.WriteLine(account.deposit(225, "salary", "employer", "blank"));

            //adding dummy transactions
            account.Transactions.Add(new AccountTransaction(DateTime.Now.AddDays(-3), 100, 200, "food", "waitrose", "withdraw","apples"));
            account.Transactions.Add(new AccountTransaction(DateTime.Now.AddDays(-2), 100, 500, "food", "waitrose", "withdraw", "apples"));
            account.Transactions.Add(new AccountTransaction(DateTime.Now.AddDays(-1), 100, 1000, "food", "waitrose", "withdraw", "apples"));

            //check previous balance
            DateTime dateCheck = DateTime.Now.AddDays(-2);
            Console.WriteLine(account.prevBalance(dateCheck));

            //check spending over time

            DateTime startDate = DateTime.Now.AddDays(-5);
            DateTime endDate = DateTime.Now;

            Console.WriteLine(account.spendingOverTime(startDate, endDate));

            //check spending in a category

            Console.WriteLine(account.spendingCategory("food"));

            //interest rates
            Console.WriteLine(account.interestPayment(1.05));


        }
    }
}

