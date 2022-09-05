using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using HtmlConverter;
using PdfiumViewer;

using PdfiumDocument = PdfiumViewer.PdfDocument;
using PdfSharpDocument = PdfSharp.Pdf.PdfDocument;
using PdfSharpPage = PdfSharp.Pdf.PdfPage;

namespace HtmlConverter
{
    public static class PdfSharpExtension
    {
        public static PdfiumDocument ToFiumDocument(this PdfSharpDocument pdfSharpDoc)
        {
            PdfiumDocument pdfiumDoc = null;

            using (MemoryStream stream = new MemoryStream())
            {
                pdfSharpDoc.Save(stream, false);
                pdfiumDoc = PdfiumDocument.Load(stream);
            }

            return pdfiumDoc;
        }

      
        public static ImageWrapper ToImage(this PdfiumDocument pdfiumDoc, int idx)
        {
            //if (idx >= pdfiumDoc.Pages.Count || idx < 0)
            //    throw new ArgumentOutOfRangeException(nameof(idx));

            //PdfiumPage page = pdfiumDoc.Pages[idx];

            //int width = (int)page.Width;
            //int height = (int)page.Height;

            //PDFiumBitmap bitmap = new PDFiumBitmap(width, height, true);

            //var image = document.Render(0, 300, 300, true);
            //image.Save(@"output.png", ImageFormat.Png);
            //PdfiumViewer.PdfDocument.Load()

            //return new ImageWrapper(bitmapImage);
            return null;
        }

       
    }
}
