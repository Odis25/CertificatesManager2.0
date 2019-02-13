using System;
using System.Collections.Generic;
using CertificatesModel.Components;
using CertificatesModel.Interfaces;
using CertificatesModel.Repositories;
using System.IO;

namespace CertificatesModel
{
    public class CertificatesLoader : ICertificatesLoader
    {

        // Получить весь список свидетельств
        public Certificates GetAllCertificates()
        {
            Certificates result = CertificatesRepository.Certificates;
            //Certificates result = CertificatesRepository.GetAllCertificatesFromDB();
            return result;
        }

        // Получить список свидетельств соответствующих шаблону
        public Certificates GetCertificatesBySearchPattern(CertificateEventArgs pattern)
        {
            Certificates result = CertificatesRepository.GetAllCertificatesFromDB(pattern);
            return result;
        }

        public void AddNewCertificate(Certificate certificate, byte[] byteArray)
        {
            var checkedContractNumber = string.Join("-", certificate.ContractNumber.Split(Path.GetInvalidFileNameChars()));
            var checkedDeviceType = string.Join("-", certificate.DeviceType.Split(Path.GetInvalidFileNameChars()));
            var checkedDeviceName = string.Join("-", certificate.DeviceName.Split(Path.GetInvalidFileNameChars()));

            var certificatePath = $"{Settings.Instance.CertificatesFolderPath}\\{certificate.Year}\\{checkedContractNumber}\\Свидетельства\\{checkedDeviceType}_{checkedDeviceName}.pdf";

            // Проверяем есть ли такое свидетельство в базе
            //bool result = CheckIfCertificateAllreadyExist(certificate);
            //if (result) return;

            // Создаем файл свидетельства в указанном месте
            CreateFile(ref certificatePath, byteArray);
            // Указываем путь к файлу свидетельства
            certificate.CertificatePath = certificatePath;

            CertificatesRepository.AddNewCertificate(certificate);
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

        private bool CheckIfCertificateAllreadyExist(Certificate certificate)
        {
            throw new NotImplementedException();
        }

        // Создаем файл с уникальным именем пути
        private void CreateFile(ref string certificatePath, byte[] byteArray)
        {
            var dir = Path.GetDirectoryName(certificatePath);
            var extension = Path.GetExtension(certificatePath);
            var fileName = Path.GetFileNameWithoutExtension(certificatePath);

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
