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
    {
        [TestCase(1, -2)]
        [TestCase(0, 3)]
        [TestCase(int.MaxValue, -5)]
        [TestCase(int.MaxValue, int.MaxValue)]
        [TestCase(1000, 1)]
        public void Sum_returnsSum(int lhs, int rhs)
        {   //arrange
            var sut = new Calculator();

            //act
            var expected = lhs + rhs;
            
            //asert
            Assert.AreEqual(sut.Sum(lhs, rhs), expected);
        }


    }
}
