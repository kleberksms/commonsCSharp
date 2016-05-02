using System;
using NUnit.Framework;

namespace Validation.Test
{
    [TestFixture]
    public class ConsonantTest
    {
        [Test]
        public void TestIfIsConsonant()
        {
            var consonant = "b";
            var con = new Consonant(consonant);
            Assert.IsTrue(con.IsConsonant());
        }

        [Test]
        public void TestIfIsSetOfConsonant()
        {
            var consonant = "bcdf";
            var con = new Consonant(consonant);
            Assert.IsTrue(con.IsSetOfConsonants());
        }
        [Test]
        public void TestIfIsSetOfConsonantIsInvalid()
        {
            var consonant = "abcdf";
            var con = new Consonant(consonant);
            Assert.IsFalse(con.IsSetOfConsonants());
        }

        [Test]
        public void TestIfContainsConsonant()
        {
            var consonant = "abcdef";
            var con = new Consonant(consonant);
            Assert.IsTrue(con.ContainsConsonant());
        }
    }
}
