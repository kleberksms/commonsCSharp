using NUnit.Framework;

namespace Validation.Test
{
    [TestFixture]
    public class CnhTest
    {
        [Test]
        public void ValidCnhTest()
        {
            var cnh = new Cnh("04592402198");
            Assert.IsTrue(cnh.IsValid());
        }

        [Test]
        public void InvalidCnhTest()
        {
            var cnh = new Cnh("78258015104");
            Assert.IsFalse(cnh.IsValid());
        }
        [Test]
        public void CnhLess14CharsTest()
        {
            var cnh = new Cnh("79258070112304");
            Assert.IsFalse(cnh.IsValid());
        }
    }
}
