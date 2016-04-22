using NUnit.Framework;

namespace Validation.Test
{
    [TestFixture]
    public class CnpjTest
    {
        [Test]
        public void ValidCnpjTest()
        {
            var cnpj = new Cnpj("03.404.018/0015-42");
            Assert.AreEqual(cnpj.IsValid(),true);
        }
   
        [Test]
        public void InvalidCnpjTest()
        {
            var cnpj = new Cnpj("03.404.018/1015-42");
            Assert.AreEqual(cnpj.IsValid(), false);
        }
        [Test]
        public void CnpjLess14CharsTest()
        {
            var cnpj = new Cnpj("03.404.018/05-42");
            Assert.AreEqual(cnpj.IsValid(), false);
        }
    }
}
