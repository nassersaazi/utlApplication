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
    public class CalculatorTest
    {   [Test]
        public void Sum_returnsSum()
        {
            var sut = new Calculator();
            var sum = sut.Sum(3, 1);
            Assert.AreEqual(4,sum);
        }
    }
}
