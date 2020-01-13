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
        {   //arrange
            var sut = new Calculator();

            //act
            var sum = sut.Sum(3, 1);

            //asert
            Assert.AreEqual(4,sum);
        }
    }
}
