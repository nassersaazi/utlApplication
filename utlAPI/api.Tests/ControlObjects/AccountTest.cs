using api.ControlObjects;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Tests.ControlObjects
{
    [TestFixture]
    public class AccountTest
    {
        public static IEnumerable<TestCaseData> CreditDecisionTestData
        {
            get
            {
                yield return new TestCaseData(100, "Declined");
                yield return new TestCaseData(549, "Declined");
                yield return new TestCaseData(550, "Maybe");
                yield return new TestCaseData(674, "Maybe");
                yield return new TestCaseData(675, "Maybe");
                yield return new TestCaseData(676, "We look forward to doing business with you!");
            }
        }

        [Test]
        public void TransferFunds()
        {
            Account source = new Account();
            source.Deposit(200m);

            Account destination = new Account();
            destination.Deposit(150m);

            source.TransferFunds(destination, 100m);

            Assert.AreEqual(250m, destination.Balance);
            Assert.AreEqual(100m, source.Balance);

        }

        //[TestCase(100, "Declined")]
        //[TestCase(int.MinValue, "Declined")]
        //[TestCase(-1, "Declined")]
        //[TestCase(0, "Declined")]
        //[TestCase(549, "Declined")]
        //[TestCase(550, "Maybe")]
        //[TestCase(675, "Maybe")]
        //[TestCase(676, "We look forward to doing business with you!")]
        //[TestCase(int.MaxValue, "We look forward to doing business with you!")]
        [TestCaseSource(typeof(AccountTest), "CreditDecisionTestData")]
        public void MakeCreditDecision_Always_ReturnsExpectedResult(int creditScore, string expectedResult)
        {
            
           // Refactored to use TestCaseSource
            Account acc = new Account();
            var result = acc.MakeCreditDecision(creditScore);
            Assert.That(result, Is.EqualTo(expectedResult));
        }

    }


}
