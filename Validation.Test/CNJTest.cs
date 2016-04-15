using NUnit.Framework;

namespace Validation.Test
{
    [TestFixture]
    public class CnjTest
    {


        [Test]
        public void IsValidCnj2015()
        {
            var cnj = new Cnj("0003182-81.2015.821.0139");
            Assert.AreEqual(cnj.IsValid(), true);
        }

        [Test]
        public void IsInvalidCnj2015()
        {
            var cnj = new Cnj("0003182-84.2015.821.0139");
            Assert.AreEqual(cnj.IsValid(), false);
        }

        [Test]
        public void IsValidCnj2013()
        {
            var cnj = new Cnj("0729942-51.2013.802.0001");
            Assert.AreEqual(cnj.IsValid(), true);
        }

        [Test]
        public void CnjComMenosDe20Chars()
        {
            var cnj = new Cnj("3182-81.2015.821.0139");
            Assert.AreEqual(cnj.IsValid(), true);
        }


        [Test]
        public void CnjSemDigitoVerificador()
        {
            var cnj = new Cnj("0003182-81.2015.821.0139");
            Assert.AreEqual(cnj.CnjSemDigitoVerificador(), "000318220158210139");
        }

        [Test]
        public void CnjDigitoVerificador()
        {
            var cnj = new Cnj("0003182-81.2015.821.0139");
            Assert.AreEqual(cnj.DigitoVerificador(), "81");
        }

        [Test]
        public void CalculoDigitoVerificadorTest()
        {
            var cnj = new Cnj("0003182-81.2015.821.0139");
            var cnjSemDigito = cnj.CnjSemDigitoVerificador();
            Assert.AreEqual(cnj.CalculoDigitoVerificador(cnjSemDigito), "81");
        }


    }
}
