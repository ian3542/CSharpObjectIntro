using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CSharpObjectIntro.Classes.BankAccount
{
    public class AccountTransaction
    {
        public AccountTransaction(DateTime date, double amount, double newBalance, string category, string counterparty, string transactionType, string description)
        {
            Date = date;
            Amount = amount;
            Category = category;
            Counterparty = counterparty;
            TransactionType = transactionType;
            Description = description;
            NewBalance = newBalance;
        }
        public DateTime Date { get; private set; }
        public double Amount { get; private set; }
        public string Category { get; private set; }
        public string Counterparty { get; private set; }
        public string TransactionType { get; private set; }
        public string Description { get; private set; }
        public double NewBalance { get; private set; }
    }
}

