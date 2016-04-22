using NUnit.Framework;

namespace Validation.Test
{
    [TestFixture]
    public class CnpjTest
    {
        [Test]
        public void ValidCnpjTest()
        {
            var cnpj = new Cnpj("45.855.406/0001-94");
            Assert.AreEqual(cnpj.IsValid(),true);
        }
   
        [Test]
        public void InvalidCnpjTest()
        {
            var cnpj = new Cnpj("45.855.407/0001-94");
            Assert.AreEqual(cnpj.IsValid(), false);
        }
        [Test]
        public void CnpjLess14CharsTest()
        {
            var cnpj = new Cnpj("45.855.406/01-94");
            Assert.AreEqual(cnpj.IsValid(), false);
        }
    }
}
