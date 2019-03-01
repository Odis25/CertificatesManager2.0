using CertificatesModel.Components;

namespace CertificatesModel.Interfaces
{
    public interface ICertificatesLoader
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
        Certificate EditCertificate(CertificateEventArgs pattern);

        /// <summary>
        /// Изменить путь к файлам
        /// </summary>
        /// <param name="idArray">Массив id изменяемых свидетельств</param>
        /// <param name="newPath">Новый путь к файлам</param>
        void ModifyFilePath(int[] idArray, string newPath);

        /// <summary>
        /// Удаление свидетельств
        /// </summary>
        /// <param name=""></param>
        void DeleteCertificates(params int[] idList);

        /// <summary>
        /// Добавление в базу нового свидетельства
        /// </summary>
        /// <param name="certificate">Новое свидетельство</param>
        bool AddNewCertificate(Certificate certificate, byte[] byteArray);
    }
}
