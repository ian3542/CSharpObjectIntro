using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSharpObjectIntro.Classes.BankAccount;

namespace CSharpObjectIntro.Tests
{
    [TestClass]
    public class BankAccountTests
    {
        [TestMethod]
        public void TestBankAccount()
        {
            var BankAccount = new BankAccount(0);
            Assert.AreEqual(0, BankAccount.Balance);
        }
    }
}