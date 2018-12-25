using CertificatesModel.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertificatesModel.Interfaces
{
    public interface ILoader
    {
        /// <summary>
        /// Получить список всех свидетельств из БД
        /// </summary>
        /// <returns></returns>
        Certificates GetAllCertificates();
        /// <summary>
        /// Получить список свидетельств соответствующих шаблону
        /// </summary>
        /// <param name="pattern"></param>
        /// <returns></returns>
        Certificates GetCertificatesBySearchPattern(CertificateEventArgs pattern);
        /// <summary>
        /// Внести изменения в свидетельство
        /// </summary>
        /// <param name="pattern"></param>
        /// <returns></returns>
        void EditCertificate(CertificateEventArgs pattern);
    }
}
