using NUnit.Framework;

namespace Validation.Test
{
    [TestFixture]
    public class PrimeNumberTest
    {
        [Test]
        public void TestIfIsPrimeNumber()
        {
            var pn = new PrimeNumber(7);
            Assert.IsTrue(pn.IsPrime());
        }

        [Test]
        public void TestIf9IsPrimeNumber()
        {
            var pn = new PrimeNumber(9);
            Assert.IsFalse(pn.IsPrime());
        }

        [Test]
        public void TestIf47IsPrimeNumber()
        {
            var pn = new PrimeNumber(47);
            Assert.IsTrue(pn.IsPrime());
        }
        
        [Test]
        public void TestIfNotIsPrimeNumber()
        {
            var pn = new PrimeNumber(6);
            Assert.IsFalse(pn.IsPrime());
        }

        [Test]
        public void TestIf25404451IsPrimeNumber()
        {
            var pn = new PrimeNumber(25404451);
            Assert.IsTrue(pn.IsPrime());
        }
    }
}
