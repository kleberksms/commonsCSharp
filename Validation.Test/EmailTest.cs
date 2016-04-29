using NUnit.Framework;

namespace Validation.Test
{
    [TestFixture]
    public class EmailTest
    {
        [Test]
        public void TestValidEmail()
        {
            var e = "someone@somewhere.com";
            var email = new Email(e);
            Assert.IsTrue(email.IsValid());
        }

        [Test]
        public void TestInvalidEmail()
        {
            var e = "someone@somewhere.";
            var email = new Email(e);
            Assert.IsFalse(email.IsValid());
        }

        [Test]
        public void TestInvalidEmailDomain()
        {
            var e = "someone@poxqts.com";
            var email = new Email(e);
            email.validDomain = true;
            Assert.IsFalse(email.IsValid());
        }

        [Test]
        public void TestValidEmailDomain()
        {
            var e = "someone@gmail.com";
            var email = new Email(e);
            email.validDomain = true;
            Assert.IsTrue(email.IsValid());
        }
    }
}
