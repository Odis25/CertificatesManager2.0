using System;
using System.Collections.Generic;
using CertificatesModel.Components;
using CertificatesModel.Interfaces;
using CertificatesModel.Repositories;

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
    }
}
