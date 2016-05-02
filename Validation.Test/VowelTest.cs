using NUnit.Framework;

namespace Validation.Test
{
    [TestFixture]
    public class VowelTest
    {
        [Test]
        public void TestIfIsVowel()
        {
            var vowel = "a";
            var v = new Vowel(vowel);
            Assert.IsTrue(v.IsVowel());
        }

        [Test]
        public void TestIfIsSetOfVowel()
        {
            var vowel = "uoia";
            var v = new Vowel(vowel);
            Assert.IsTrue(v.IsSetOfVowels());
        }
        [Test]
        public void TestIfIsSetOfVowelIsInvalid()
        {
            var vowel = "abcdf";
            var con = new Vowel(vowel);
            Assert.IsFalse(con.IsSetOfVowels());
        }

        [Test]
        public void TestIfContainsVowel()
        {
            var vowel = "abcdef";
            var v = new Vowel(vowel);
            Assert.IsTrue(v.ContainsVowel());
        }
    }
}
