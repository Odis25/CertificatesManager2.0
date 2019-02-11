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
        public byte[] ScanNewCertificate(bool duplex)
        {
            Scanner scanner = new Scanner();
            ScanSaver saver = new ScanSaver();

            var imageList = scanner.Scan(duplex);
            return saver.SaveToByteArray(imageList);
        }

        public byte[] AddPagesToScannedCertificate(byte[] sourceArray, bool duplex)
        {
            Scanner scanner = new Scanner();
            ScanSaver saver = new ScanSaver();

            var imageList = scanner.Scan(duplex);
            var result = saver.AddNewPagesToDocument(imageList, sourceArray);
            return result;
        }
    }
}
