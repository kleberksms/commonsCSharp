using NUnit.Framework;

namespace Validation.Test
{
    [TestFixture()]
    public class NfeAccessKeyTest
    {
        [Test]
        public void TestValidAccesKeyDanfeNfe()
        {
            var danfeAccessKey = "42-10/04-84.684.182/0001-57-55-001-000.000.002-010.804.210-8";

            var nfe = new NfeAccessKey(danfeAccessKey);
            Assert.IsTrue(nfe.IsValid());
        }

        [Test]
        public void TestInvalidAccesKeyDanfeNfe()
        {
            var danfeAccessKey = "42-10/04-84.741.182/0001-57-55-001-000.000.002-010.804.210-8";

            var nfe = new NfeAccessKey(danfeAccessKey);
            Assert.IsFalse(nfe.IsValid());
        }
    }
}
