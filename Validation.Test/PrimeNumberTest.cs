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
        public void TestIfNotIsPrimeNumber()
        {
            var pn = new PrimeNumber(6);
            Assert.IsFalse(pn.IsPrime());
        }
    }
}
