using System.Collections.Generic;
using NUnit.Framework;
namespace Filter.Test
{
    [TestFixture]
    public class StringTest
    {
        [Test]
        public void SlugfyTest()
        {
            Assert.AreEqual("my-text", "My Text".Slugfy());
            Assert.AreEqual("text-with-ola-mundo-cc", "Text With Olá Mundo çÇ".Slugfy());
        }

        [Test]
        public void ExcerptTest()
        {
            Assert.AreEqual("Lorem ipsum dolor sit...", "Lorem ipsum dolor sit amet, consectetur adipiscing elit.".Excerpt(26));
            Assert.AreEqual("Lorem ipsum dolor sit!!!", "Lorem ipsum dolor sit amet.".Excerpt(26, "!!!"));
            Assert.AreEqual("Lorem ipsum dolor sit amet", "Lorem ipsum dolor sit amet".Excerpt(30));
            Assert.AreEqual("Lorem ipsum dolor sit amet, consectetur...", "Lorem ipsum dolor sit amet, consectetur adipiscing elit.".Excerpt(39));
        }

        [Test]
        public void OnlyNumbersTest()
        {
            Assert.AreEqual(String.OnlyNumbers("023456/12346"), "02345612346");
            Assert.AreEqual(String.OnlyNumbers("023@#%456/12346"), "02345612346");
            Assert.AreEqual(String.OnlyNumbers("023456/12346"), "02345612346");
            Assert.AreEqual(String.OnlyNumbers("023456/123-[]46"), "02345612346");
            Assert.AreEqual(String.OnlyNumbers("023456/12ºªº346"), "02345612346");
            Assert.AreEqual(String.OnlyNumbers("02£³¬¢¬¬¬3456/12346"), "02345612346");
        }

        [Test]
        public void FindByMaskOnlySimpleNumberTest()
        {
            Assert.AreEqual(String.FindFirstByMaskExpression("000","hello world 123 456"), "123");
        }

        [Test]
        public void FindByMaskOnlyNumberTest()
        {
            Assert.AreEqual(String.FindFirstByMaskExpression("000.000.000-00", "teste gasuygdfuguyt uyasgfuyasdgfuy sdgf sdu qualquer 123.123.599-50"), "123.123.599-50");
        }

        [Test]
        public void FindByMaskOnlyTextTest()
        {
            Assert.AreEqual(String.FindFirstByMaskExpression("AAA-AAA-AAA", "teste qualquer 123.123.599.50 OUD-bhd-TES"), "OUD-bhd-TES");
        }

        [Test]
        public void FindByMaskCNJTest()
        {
            Assert.AreEqual(String.FindFirstByMaskExpression("0000000-00.0000.000.0000", "teste qualquer 123.123.599.50 OUD-bhd-TES 0003182-81.2015.821.0139"), "0003182-81.2015.821.0139");
        }


        [Test]
        public void FindListByMask()
        {
            var list = new List<string> {"01-02-03", "12-34-56", "85-74-96"};
            CollectionAssert.AreEqual(list, String.FindListByMaskExpression("00-00-00", "test with 01-02-03 and 12-34-56 and others numbers 85-74-96"));
            
        }

        [Test]
        public void IfFormatCorrectRegexWithHyphenForMaskTest()
        {
            Assert.AreEqual(String.FormatterRegex("AA 00000-0000"), "([A-Za-z]{2}\\s+\\d{5}(\\-)\\d{4})");
        }

        [Test]
        public void IfFormatCorrectRegexWithSpaceForMaskTest()
        {
            Assert.AreEqual(String.FormatterRegex("AA 00000 0000"), "([A-Za-z]{2}\\s+\\d{5}\\s+\\d{4})");
        }

        [Test]
        public void IfFormatCorrectRegexWithCnjForMaskTest()
        {
            Assert.AreEqual(String.FormatterRegex("0000000-00.0000.000.0000"), "(\\d{7}(\\-)\\d{2}(\\.)\\d{4}(\\.)\\d{3}(\\.)\\d{4})");
        }

        [Test]
        public void StringBetweenTest()
        {
            Assert.AreEqual(String.GetBetween("This is an example string and my data is here","my","is"),"data");
        }

        [Test]
        public void StringBetweenIncludeTest()
        {
            Assert.AreEqual(String.GetBetween("This is an example string and my data is here", "my", "is", true), "my data is");
        }

        [Test]
        public void OnlyAlphanumericTest()
        {
            Assert.AreEqual(String.OnlyAlphanumerics("465@54b#d!3-sf1sd51-f.dsfs4f-/4df5s1f6f"), "46554bd3sf1sd51fdsfs4f4df5s1f6f");
        }

        [Test]
        public void AddMaskTest()
        {
            Assert.AreEqual(String.AddMask("0000000-00.0000.000.0000","12345671212341231234"),"1234567-12.1234.123.1234");
        }

    }
}
