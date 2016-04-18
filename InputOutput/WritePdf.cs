using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace InputOutput
{
    public class WritePdf
    {
        private PdfReader _reader;
        private PdfContentByte _cb;
        private Document _document;
        private FileStream _fs;
        private PdfWriter _writer;
        private Rectangle _size;
        private BaseFont _bf;

        public WritePdf UpdatePdf(string oldPathFile, string newPathFile)
        {
            _reader = new PdfReader(oldPathFile);
            _size = _reader.GetPageSizeWithRotation(1);
            _document = new Document(_size);
            _fs = new FileStream(newPathFile, FileMode.OpenOrCreate, FileAccess.Write);
            _writer = PdfWriter.GetInstance(_document, _fs);
            _document.Open();
            _cb = _writer.DirectContent;
            SetFont();
            SetColor();
            SetFontSize();
            return this;
        }

        public WritePdf SetFont()
        {
            _bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            return this;
        }

        public WritePdf SetColor()
        {
            _cb.SetColorFill(BaseColor.DARK_GRAY);
            return this;
        }

        public WritePdf SetFontSize()
        {
            _cb.SetFontAndSize(_bf,8);
            return this;
        }

        public WritePdf AddText(int alignment, string text, float x, float y, float rotation)
        {
            _cb.BeginText();
            _cb.ShowTextAligned(alignment,text,x,y,rotation);
            _cb.EndText();
            return this;
        }

        public void Execute()
        {
            _document.Close();
            _fs.Close();
            _writer.Close();
            _reader.Close();
        }



    }
}
