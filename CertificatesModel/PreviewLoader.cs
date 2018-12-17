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

        public Pages Load(string path)
        {
            var result = (GetPagesFromPdf(path)).Result;

            return result;
        }

        async private Task<Pages> GetPagesFromPdf(string path)
        {
            if (_cts != null)
                _cts.Cancel();

            var cts = new CancellationTokenSource();
            var token = cts.Token;

            using (var document = await Task.Run(new Func<PdfDocument>(() => { return PdfDocument.Load(path); }), token))
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

                    imageList.Add(await Task<Image>.Factory.StartNew(RenderAsync, data));
                }

                if (_cts == cts)
                    _cts = null;

                return imageList;
            }
        }

        private Image RenderAsync(object obj) // Асинхронная версия метода Render PDF
        {
            Context data = (Context)obj;
            CancellationToken token = data.ct;

            token.ThrowIfCancellationRequested();

            return data.document.Render(data.i, data.dpiX, data.dpiY, data.isPrinting);
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
