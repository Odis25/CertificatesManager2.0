using CertificatesModel.Components;
using CertificatesModel.Interfaces;
using CertificatesModel.Repositories;
using System.IO;
using System.Linq;

namespace CertificatesModel
{
    public class CertificatesLoader : ICertificatesLoader
    {

        // Получить весь список свидетельств
        public Certificates GetAllCertificates()
        {
            return CertificatesRepository.Certificates;
        }

        // Получить список свидетельств соответствующих шаблону
        public Certificates GetCertificatesBySearchPattern(CertificateEventArgs pattern)
        {
            Certificates result = CertificatesRepository.GetSelectedCertificatesFromDB(pattern);
            return result;
        }

        // Добавить нового свидетельства
        public bool AddNewCertificate(Certificate certificate, byte[] byteArray)
        {
            var checkedContractNumber = string.Join("-", certificate.ContractNumber.Split(Path.GetInvalidFileNameChars()));
            var checkedDeviceType = string.Join("-", certificate.DeviceType.Split(Path.GetInvalidFileNameChars()));
            var checkedDeviceName = string.Join("-", certificate.DeviceName.Split(Path.GetInvalidFileNameChars()));

            var certificatePath = $"{Settings.Instance.CertificatesFolderPath}\\{certificate.Year}\\{checkedContractNumber}\\Свидетельства\\{checkedDeviceType}_{checkedDeviceName}.pdf";

            // Проверяем есть ли такое свидетельство в базе
            if (CheckIfCertificateAllreadyExist(certificate))
                return false;

            // Создаем файл свидетельства в указанном месте
            CreateFile(ref certificatePath, byteArray);
            // Указываем путь к файлу свидетельства
            certificate.CertificatePath = certificatePath;

            CertificatesRepository.AddNewCertificate(certificate);
            return true;
        }

        // Изменить свидетельство согласно шаблону
        public void EditCertificate(CertificateEventArgs pattern)
        {
            CertificatesRepository.EditCertificate(pattern);
        }

        // Удалить выбранные свидетельства
        public void DeleteCertificates(params int[] idList)
        {
            CertificatesRepository.DeleteCertificates(idList);
        }

        // Проверяем существует ли такое свидетельство в базе
        private bool CheckIfCertificateAllreadyExist(Certificate certificate)
        {
            return CertificatesRepository.Certificates.Any(x => x.SerialNumber == certificate.SerialNumber && x.CalibrationDate == certificate.CalibrationDate);
        }

        // Создаем файл с уникальным именем пути
        private void CreateFile(ref string certificatePath, byte[] byteArray)
        {
            var dir = Path.GetDirectoryName(certificatePath);
            var extension = Path.GetExtension(certificatePath);
            var fileName = Path.GetFileNameWithoutExtension(certificatePath);

            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            certificatePath = Path.Combine(dir, fileName + extension);
            // Если файл с таким именем существует
            for (int i = 0; ; i++)
            {
                if (!File.Exists(certificatePath))
                {
                    break;
                }

                if (byteArray.LongLength == new FileInfo(certificatePath).Length)
                    return;

                certificatePath = Path.Combine(dir, fileName + $"_({i})" + extension);
            }

            // Записываем в созданный файл данные в бинарном формате
            using (BinaryWriter writer = new BinaryWriter(File.Create(certificatePath)))
            {
                writer.Write(byteArray);
                writer.Flush();
                writer.Close();
            }
        }

    }
}
