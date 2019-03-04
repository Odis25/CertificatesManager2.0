using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Collections.Generic;
using System.IO;

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
                        Image pic = Image.GetInstance(image, System.Drawing.Imaging.ImageFormat.Jpeg);
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

        /// <summary>
        /// Сохранение изображений в массив байт
        /// </summary>
        /// <param name="scansList">Список изображений</param>
        /// <returns>pdf-файл в виде массива байт</returns>
        public byte[] SaveToByteArray(IEnumerable<System.Drawing.Image> scansList)
        {
            using (Document doc = new Document(iTextSharp.text.PageSize.A4))
            {
                using (MemoryStream stream = new MemoryStream())
                {
                    PdfWriter.GetInstance(doc, stream);
                    doc.Open();

                    foreach (var image in scansList)
                    {
                        Image pic = Image.GetInstance(image, System.Drawing.Imaging.ImageFormat.Jpeg);
                        pic.SetAbsolutePosition(0, 0);
                        pic.ScaleAbsoluteHeight(doc.PageSize.Height);
                        pic.ScaleAbsoluteWidth(doc.PageSize.Width);
                        doc.Add(pic);
                        doc.NewPage();
                    }
                    doc.Close();
                    return stream.ToArray();
                }
            }
        }

        public byte[] AddNewPagesToDocument(IEnumerable<System.Drawing.Image> scansList, byte[] sourceArray)
        {
            using (Document doc = new Document(iTextSharp.text.PageSize.A4))
            {
                using (MemoryStream result = new MemoryStream())
                {
                    PdfReader reader = new PdfReader(sourceArray);
                    PdfConcatenate concatenator = new PdfConcatenate(result);
                    concatenator.AddPages(reader);

                    using (MemoryStream stream = new MemoryStream())
                    {
                        PdfWriter.GetInstance(doc, stream);
                        doc.Open();
                        foreach (var image in scansList)
                        {
                            Image pic = Image.GetInstance(image, System.Drawing.Imaging.ImageFormat.Jpeg);
                            pic.SetAbsolutePosition(0, 0);
                            pic.ScaleAbsoluteHeight(doc.PageSize.Height);
                            pic.ScaleAbsoluteWidth(doc.PageSize.Width);
                            doc.Add(pic);
                            doc.NewPage();
                        }
                        doc.Close();
                        reader = new PdfReader(stream.ToArray());
                    }

                    concatenator.AddPages(reader);
                    reader.Close();
                    concatenator.Close();
                    return result.ToArray();
                }          
            }
        }
    }
}
