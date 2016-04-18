using InputOutput;
using NUnit.Framework;

namespace InputOutput.Test
{
    [TestFixture]
    public class ReadPdfTest
    {
        private ReadPdf _pdf;
        [SetUp]
        public void Init()
        {
            _pdf = new ReadPdf();
          
        }

        [Test]
        public void TestReadFile()
        {
            _pdf.ToText(@"C:\Users\bellinati\Documents\pdf.pdf");

        }

    }
}
