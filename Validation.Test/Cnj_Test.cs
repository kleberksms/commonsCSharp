using NUnit.Framework;

namespace Validation.Test
{
    [TestFixture]
    public class Cnj_Test
    {


        [Test]
        public void TestValidCnj()
        {
            var cnj = new Cnj_("0003182-81.2015.821.0139");
            Assert.IsTrue(cnj.IsValid());
        }

        [Test]
        public void TestInvalidCnj()
        {
            var cnj = new Cnj_("0003182-84.2015.821.0139");
            Assert.IsFalse(cnj.IsValid());
        }


        [Test]
        public void TestValidCnjLess20Chars()
        {
            var cnj = new Cnj_("3182-81.2015.821.0139");
            Assert.IsTrue(cnj.IsValid());
        }


    }
}
