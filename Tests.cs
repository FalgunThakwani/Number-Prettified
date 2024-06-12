using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Number_Prettifier
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void TestNumberLessThanMillion()
        {
            
            Assert.That(Service.NumberPrettified(532), Is.EqualTo("532"));
            Assert.That(Service.NumberPrettified(98765), Is.EqualTo("98765"));
            Assert.That(Service.NumberPrettified(987.65), Is.EqualTo("987.6"));
            Assert.That(Service.NumberPrettified(1.23), Is.EqualTo("1.2"));
            Assert.That(Service.NumberPrettified(123456), Is.EqualTo("123456"));
 
        }

        [Test]
        public void TestMillions()
        {
            Assert.That(Service.NumberPrettified(1234567), Is.EqualTo("1.2M"));
            Assert.That(Service.NumberPrettified(1000000), Is.EqualTo("1M"));
            Assert.That(Service.NumberPrettified(10000000), Is.EqualTo("10M"));
            Assert.That(Service.NumberPrettified(25550000), Is.EqualTo("25.5M"));
            Assert.That(Service.NumberPrettified(2500000.34), Is.EqualTo("2.5M"));
            Assert.That(Service.NumberPrettified(1000000.01), Is.EqualTo("1M")); 
            Assert.That(Service.NumberPrettified(100000000.01), Is.EqualTo("100M")); 
        }

        [Test]
        public void TestBillions()
        {
            Assert.That(Service.NumberPrettified(1123456789), Is.EqualTo("1.1B"));
            Assert.That(Service.NumberPrettified(11234567890), Is.EqualTo("11.2B"));
            Assert.That(Service.NumberPrettified(112345678900), Is.EqualTo("112.3B"));
            Assert.That(Service.NumberPrettified(987654321000), Is.EqualTo("987.6B"));
            Assert.That(Service.NumberPrettified(1000000000), Is.EqualTo("1B"));
            Assert.That(Service.NumberPrettified(1200000000), Is.EqualTo("1.2B"));
        }

        [Test]
        public void TestTrillions()
        {
            Assert.That(Service.NumberPrettified(1234567890123), Is.EqualTo("1.2T"));
            Assert.That(Service.NumberPrettified(1000000000000), Is.EqualTo("1T"));
            Assert.That(Service.NumberPrettified(1000000000000.01), Is.EqualTo("1T"));
            Assert.That(Service.NumberPrettified(9900000000000.91), Is.EqualTo("9.9T"));
            Assert.That(Service.NumberPrettified(10000900000000), Is.EqualTo("10T"));
            Assert.That(Service.NumberPrettified(220009000000000.414555), Is.EqualTo("220T"));
            Assert.That(Service.NumberPrettified(545500900000000.87991), Is.EqualTo("545.5T"));
        }

        [Test]
        public void TestBoundaryConditions()
        {
            Assert.That(Service.NumberPrettified(999999999), Is.EqualTo("999.9M"));
            Assert.That(Service.NumberPrettified(1000000000), Is.EqualTo("1B"));
            Assert.That(Service.NumberPrettified(999999999999), Is.EqualTo("999.9B"));
            Assert.That(Service.NumberPrettified(1000000000000), Is.EqualTo("1T"));
            Assert.That(Service.NumberPrettified(0.888), Is.EqualTo("0.8"));
            Assert.That(Service.NumberPrettified(999999.9999), Is.EqualTo("999999.9"));
        }

        [Test]
        public void TestLargeNumbers()
        {
            Assert.That(Service.NumberPrettified(1234567890123456), Is.EqualTo("Error: The number is too large to be processed."));
            Assert.That(Service.NumberPrettified(999999999999999), Is.EqualTo("999.9T"));
            Assert.That(Service.NumberPrettified(1000000000000000), Is.EqualTo("Error: The number is too large to be processed."));
            Assert.That(Service.NumberPrettified(1000000012500000000050000.9999999), Is.EqualTo("Error: The number is too large to be processed."));
        }

        

        [Test]
        public void TestZero()
        {
            Assert.That(Service.NumberPrettified(0), Is.EqualTo("0"));
            Assert.That(Service.NumberPrettified(0.0000), Is.EqualTo("0"));
        }
       
    }
}
