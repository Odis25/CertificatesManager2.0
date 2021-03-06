﻿using CertificatesModel.Components;
using CertificatesModel.Interfaces;
using CertificatesModel.Repositories;
using System.IO;
using System.Linq;

namespace CertificatesModel
{
    public class CertificatesLoader : ICertificatesLoader
    {

        // Получить весь список свидетельств
        public Certificates Read()
        {
            return CertificatesRepository.Certificates;
        }

        // Получить список свидетельств соответствующих шаблону
        public Certificates Read(CertificateEventArgs pattern)
        {
            Certificates result = CertificatesRepository.GetSelectedCertificatesFromDB(pattern);
            return result;
        }

        // Добавить нового свидетельства
        public bool Create(Certificate certificate, byte[] byteArray, FileType type)
        {
            var checkedContractNumber = string.Join("-", certificate.ContractNumber.Split(Path.GetInvalidFileNameChars()));
            var checkedDeviceType = string.Join("-", certificate.DeviceType.Split(Path.GetInvalidFileNameChars()));
            var checkedDeviceName = string.Join("-", certificate.DeviceName.Split(Path.GetInvalidFileNameChars()));

            var certificatePath = Path.Combine(certificate.Year.ToString(), checkedContractNumber, "Свидетельства", $"{checkedDeviceType}_{checkedDeviceName}.{type}");
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
        public Certificate Update(CertificateEventArgs pattern)
        {            
            Certificate unmodifiedCertificate;
            var baseFolder = Settings.Instance.CertificatesFolderPath;
            var certificateFolder = Path.GetDirectoryName(pattern.CertificatePath);
            var fullFolderPath = Path.Combine(baseFolder, certificateFolder);
            var extension = Path.GetExtension(pattern.CertificatePath);
            var fileName = Path.GetFileNameWithoutExtension(pattern.CertificatePath);

            // Если директории с таким именем не существует, то создаем
            if (!Directory.Exists(fullFolderPath))
                Directory.CreateDirectory(fullFolderPath);

            var fullFileName = Path.Combine(fullFolderPath, fileName + extension);
            //---------------------------------------------------------------------------
            var oldFileFolder = Path.GetDirectoryName(Path.Combine(baseFolder, pattern.OldCertificatePath));
            var oldFileName = Path.GetFileNameWithoutExtension(pattern.OldCertificatePath);

            if (oldFileFolder == fullFolderPath)
            {
                if (Path.GetFileName(pattern.OldCertificatePath) == Path.GetFileName(pattern.CertificatePath))
                {
                    return CertificatesRepository.EditCertificate(pattern);
                }
            }

            // Если файл с таким именем существует
            for (int i = 1; ; i++)
            {
                if (!File.Exists(fullFileName))
                    break;

                pattern.CertificatePath = Path.Combine(certificateFolder, fileName + $"_({i})" + extension);
                fullFileName = Path.Combine(fullFolderPath, fileName + $"_({i})" + extension);
            }
            // Записываем изменения в базу
            unmodifiedCertificate = CertificatesRepository.EditCertificate(pattern);
            // Перемещаем файл свидетельства по новому пути
            if (File.Exists(Path.Combine(baseFolder, pattern.OldCertificatePath)))
                File.Move(unmodifiedCertificate.FullCertificatePath, fullFileName);

            return unmodifiedCertificate;
        }

        // Изменить путь к файлам свидетельств
        public void UpdatePaths(int[] idArray, string newPath)
        {
            CertificatesRepository.ModifyFilePath(idArray, newPath);
        }

        // Удалить выбранные свидетельства
        public void Delete(params int[] idList)
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
            var baseFolder = Settings.Instance.CertificatesFolderPath;
            var certificateFolder = Path.GetDirectoryName(certificatePath);
            var fullFolderPath = Path.Combine(baseFolder, certificateFolder);
            var extension = Path.GetExtension(certificatePath);
            var fileName = Path.GetFileNameWithoutExtension(certificatePath);

            if (!Directory.Exists(fullFolderPath))
                Directory.CreateDirectory(fullFolderPath);

            var fullCertificatePath = Path.Combine(fullFolderPath, fileName + extension);
            // Если файл с таким именем существует
            for (int i = 0; ; i++)
            {
                if (!File.Exists(fullCertificatePath))
                {
                    break;
                }

                if (byteArray.LongLength == new FileInfo(fullCertificatePath).Length)
                    return;

                certificatePath = Path.Combine(certificateFolder, fileName + $"_({i})" + extension);
                fullCertificatePath = Path.Combine(fullFolderPath, fileName + $"_({i})" + extension);
            }

            // Записываем в созданный файл данные в бинарном формате
            using (BinaryWriter writer = new BinaryWriter(File.Create(fullCertificatePath)))
            {
                writer.Write(byteArray);
                writer.Flush();
                writer.Close();
            }
        }

    }
}
