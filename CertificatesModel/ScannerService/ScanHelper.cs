using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertificatesModel.ScannerService
{
    public class ScanHelper
    {
        public MemoryStream ScanNewCertificate(bool duplex)
        {
            Scanner scanner = new Scanner();
            ScanSaver saver = new ScanSaver();

            var imageList = scanner.Scan(duplex);
            //saver.SaveToPDF(imageList);
            return saver.SaveToStream(imageList);
        }
    }
}
