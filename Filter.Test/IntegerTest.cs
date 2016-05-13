using NUnit.Framework;

namespace Filter.Test
{
    [TestFixture]
    public class IntegerTest
    {
        [Test]
        public void TestThreePositionPrimeNumberPosition()
        {
            var findPrime  = new Filter.Integer();
            Assert.AreEqual(findPrime.FindPrimeNumber(1),2);
            Assert.AreEqual(findPrime.FindPrimeNumber(2),3);
            Assert.AreEqual(findPrime.FindPrimeNumber(3),5);
        }

        [Test]
        public void Test4PositionPrimeNumber()
        {
            var findPrime = new Filter.Integer();
            Assert.AreEqual(findPrime.FindPrimeNumber(4), 7);
        }

        [Test]
        public void Test15PositionPrimeNumber()
        {
            var findPrime = new Filter.Integer();
            Assert.AreEqual(47, findPrime.FindPrimeNumber(15));
        }

        [Test]
        public void Test1589574PositionPrimeNumber()
        {
            var findPrime = new Filter.Integer();
            Assert.AreEqual(25404451, findPrime.FindPrimeNumber(1589574));
        }
    }
}
