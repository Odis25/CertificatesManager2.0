using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertificatesModel.ScannerService
{
    internal class ScanSaver
    {
        /// <summary>
        /// Соранение изображений в формате PDF
        /// </summary>
        /// <param name="scansList">Список изображений</param>
        public void SaveToPDF(IEnumerable<System.Drawing.Image> scansList)
        {
            using (Document doc = new Document(iTextSharp.text.PageSize.A4))
            {
                using (FileStream fileStream = new FileStream("tempfile.pdf", FileMode.Create))
                {
                    PdfWriter.GetInstance(doc, fileStream);
                    doc.Open();

                    foreach (var image in scansList)
                    {
                        iTextSharp.text.Image pic = iTextSharp.text.Image.GetInstance(image, System.Drawing.Imaging.ImageFormat.Jpeg);
                        pic.SetAbsolutePosition(0, 0);
                        pic.ScaleAbsoluteHeight(doc.PageSize.Height);
                        pic.ScaleAbsoluteWidth(doc.PageSize.Width);
                        doc.Add(pic);
                        doc.NewPage();
                    }
                    doc.Close();
                }
            }
        }

        public MemoryStream SaveToStream(IEnumerable<System.Drawing.Image> scansList)
        {
            using (Document doc = new Document(iTextSharp.text.PageSize.A4))
            {
                using (MemoryStream stream = new MemoryStream())
                {
                    PdfWriter.GetInstance(doc, stream);
                    doc.Open();

                    foreach (var image in scansList)
                    {
                        iTextSharp.text.Image pic = iTextSharp.text.Image.GetInstance(image, System.Drawing.Imaging.ImageFormat.Jpeg);
                        pic.SetAbsolutePosition(0, 0);
                        pic.ScaleAbsoluteHeight(doc.PageSize.Height);
                        pic.ScaleAbsoluteWidth(doc.PageSize.Width);
                        doc.Add(pic);
                        doc.NewPage();
                    }
                    doc.Close();
                    return stream;
                }
            }
        }
    }
}
