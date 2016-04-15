using IO;
using NUnit.Framework;

namespace OI.Test
{
    [TestFixture]
    public class WritePdfTest
    {
        [Test]
        public void TestEditPdf()
        {
            var pdf = new WritePdf();
            pdf.UpdatePdf(@"C:\Users\bellinati\Documents\pdf.pdf", @"C:\Users\bellinati\Documents\pdfnew.pdf");
            pdf.AddText(1, "TESTE NOVA LINHA", 500, 500, 0);
            pdf.AddText(2, "TESTE NOVA LINHA DOIS", 520, 520, 0);
            pdf.Execute();
        }
    }
}
