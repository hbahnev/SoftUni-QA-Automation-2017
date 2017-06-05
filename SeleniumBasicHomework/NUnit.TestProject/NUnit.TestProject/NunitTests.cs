using ConsoleApplication1;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit.TestProject
{
    [TestFixture]
    public class NunitTests
    {
        [Test]
        public void AcountInitializeWithNegaiveValue()
        {
            Assert.Throws<ArgumentException>(() => new BankAccount(-100m));
        }
        [Test]
        public void WithdrawAmountLessThanThousand()
        {
            BankAccount account = new BankAccount(2000m);
            var WithdrawSum = 100m;
            account.Withdraw(WithdrawSum);
            var expected = account.Amount - WithdrawSum - WithdrawSum * 0.02m;
            Assert.AreEqual(expected, account.Amount);
        }
        [Test]
        public void WithdrawAmountThousandOrMore()
        {
            BankAccount account = new BankAccount(2000m);
            var WithdrawSum = 1200m;
            account.Withdraw(WithdrawSum);
            var expected = account.Amount - WithdrawSum - WithdrawSum * 0.05m;
            Assert.AreEqual(expected, account.Amount);
        }
        [Test]
        public void AcountInitializeWithPositiveValue()
        {
            BankAccount acount = new BankAccount(2000m);
            Assert.AreEqual(2000m, acount.Amount);
        }
        [Test]
        public void AcountDepositNegativeAmount()
        {
            BankAccount acount = new BankAccount(200m);
            Assert.Throws<ArgumentException>(() => acount.Deposit(-300m));
        }
        [Test]
        public void FirstAccountGreaterThanSecondAccount()
        {
            BankAccount FirstAccount = new BankAccount(2000m);
            BankAccount SecondtAccount = new BankAccount(1999m);
            Assert.Greater(FirstAccount.Amount, SecondtAccount.Amount);
        }
        [Test]
        public void FirstAccountLessThanSecondAccount()
        {
            BankAccount FirstAccount = new BankAccount(123m);
            BankAccount SecondtAccount = new BankAccount(321m);
            Assert.Less(FirstAccount.Amount, SecondtAccount.Amount);
        }
        [Test]
        public void WithdrawIsNotAsAmount()
        {
            BankAccount FirstAccount = new BankAccount(10m);
            var WithdrawSum = 1m;
            FirstAccount.Withdraw(WithdrawSum);
            Assert.AreNotEqual(WithdrawSum, FirstAccount.Amount);
        }
    }
}
