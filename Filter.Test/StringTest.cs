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
    }
}
