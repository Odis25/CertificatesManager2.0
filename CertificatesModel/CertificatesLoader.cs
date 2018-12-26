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
            Certificates result = Repository.GetAllCertificatesFromDB();
            return result;
        }

        // Получить список свидетельств соответствующих шаблону
        public Certificates GetCertificatesBySearchPattern(CertificateEventArgs pattern)
        {
            Certificates result = Repository.GetAllCertificatesFromDB(pattern);
            return result;
        }

        // Изменить свидетельство согласно шаблону
        public void EditCertificate(CertificateEventArgs pattern)
        {
            Repository.EditCertificate(pattern);
        }

        // Удалить выбранные свидетельства
        public void DeleteCertificates(params int[] idList)
        {
            Repository.DeleteCertificates(idList);
        }
    }
}
