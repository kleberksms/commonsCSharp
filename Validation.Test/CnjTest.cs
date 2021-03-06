﻿using NUnit.Framework;

namespace Validation.Test
{
    [TestFixture]
    public class CnjTest
    {


        [Test]
        public void TestValidCnj()
        {
            var cnj = new Cnj("0003182-81.2015.8.21.0139");
            Assert.IsTrue(cnj.IsValid());
        }

        [Test]
        public void TestInvalidCnj()
        {
            var cnj = new Cnj("0003182-84.2015.8.21.0139");
            Assert.IsFalse(cnj.IsValid());
        }


        [Test]
        public void TestValidCnjLess20Chars()
        {
            var cnj = new Cnj("3182-81.2015.821.0139");
            Assert.IsTrue(cnj.IsValid());
        }


    }
}
