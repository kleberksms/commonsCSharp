using System;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

namespace IO
{
    public class ReadPdf
    {

        public string ToText(string path)
        {
            string text;
            try
            {
                PdfReader reader = new PdfReader(path);
                text = string.Empty;
                for (int page = 1; page <= reader.NumberOfPages; page++)
                {
                    text += PdfTextExtractor.GetTextFromPage(reader, page);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return text;
        }


    }
}
