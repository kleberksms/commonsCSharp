using NUnit.Framework;

namespace Validation.Test
{
    [TestFixture]
    public class CnjTest
    {


        [Test]
        public void TestValidCnj()
        {
            var cnj = new Cnj("0003182-81.2015.821.0139");
            Assert.AreEqual(cnj.IsValid(), true);
        }

        [Test]
        public void TestInvalidCnj()
        {
            var cnj = new Cnj("0003182-84.2015.821.0139");
            Assert.AreEqual(cnj.IsValid(), false);
        }


        [Test]
        public void TestValidCnjLess20Chars()
        {
            var cnj = new Cnj("3182-81.2015.821.0139");
            Assert.AreEqual(cnj.IsValid(), true);
        }


    }
}
