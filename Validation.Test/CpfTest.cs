using NUnit.Framework;

namespace Validation.Test
{
    [TestFixture]
    public class CpfTest
    {
        [Test]
        public void ValidCpfTest()
        {
            var cpf = new Cpf("585.056.827-18");
            Assert.AreEqual(cpf.IsValid(),true);
        }

        [Test]
        public void InvalidCpfTest()
        {
            var cpf = new Cpf("585.056.887-18");
            Assert.AreEqual(cpf.IsValid(), false);
        }
    }
}
