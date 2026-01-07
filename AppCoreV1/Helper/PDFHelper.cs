

using SelectPdf;

namespace AppCoreV1.Helper
{
    public class PDFHelper: IDisposable
    {
        public PDFHelper()
        {

        }

        public async Task<byte[]> DownloadPage(string strURL)
        {
            byte[] bytes = null!;
            HtmlToPdf converter = new HtmlToPdf();
            try
            {
                converter.Options.MaxPageLoadTime = 1200;
                converter.Options.PdfPageSize = PdfPageSize.A4;
                converter.Options.PdfPageOrientation = PdfPageOrientation.Portrait;
                converter.Options.MarginLeft = 10;
                converter.Options.MarginRight = 10;
                converter.Options.MarginTop = 10;
                converter.Options.MarginBottom = 10;

                SelectPdf.PdfDocument doc = converter.ConvertUrl(strURL);

                MemoryStream ms = new MemoryStream();   
                doc.Save(ms);
                ms.Position = 0;

                doc.Close();
                bytes = ms.ToArray();

            }
            catch
            {
                throw;
            }

            return await Task.FromResult(bytes);
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}
