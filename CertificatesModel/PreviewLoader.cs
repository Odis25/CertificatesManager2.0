using CertificatesModel.Interfaces;
using PdfiumViewer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CertificatesModel
{
    class PreviewLoader : IPreview
    {
        CancellationTokenSource _cts;

        async public Task<Pages> GetPagesFromPdf(string path, CancellationToken token)
        {

            //using (var document = await Task.Run(new Func<PdfDocument>(() => { return PdfDocument.Load(path); }), token))
            using (var document = PdfDocument.Load(path) )
            {
                Pages imageList = new Pages();

                for (int i = 0; i < document.PageCount; i++)
                {
                    Context data;
                    data.i = i;
                    data.dpiX = 300;
                    data.dpiY = 300;
                    data.document = document;
                    data.ct = token;
                    data.isPrinting = false;

                    var r = await Task<Image>.Factory.StartNew(RenderAsync, data);

                    if (token.IsCancellationRequested)
                        return null;

                    imageList.Add(r);
                }

                return imageList;
            }
        }

        private Image RenderAsync(object obj) // Асинхронная версия метода Render PDF
        {
            try
            {
                Context data = (Context)obj;
                CancellationToken token = data.ct;

                token.ThrowIfCancellationRequested();

                var result = data.document.Render(data.i, data.dpiX, data.dpiY, data.isPrinting);
                return result;
            }
            catch (Exception e)
            {
                return null;
            }                      
        }

        struct Context
        {
            public CancellationToken ct;
            public int i;
            public int dpiX;
            public int dpiY;
            public bool isPrinting;
            public PdfDocument document;
        }

    }
}
