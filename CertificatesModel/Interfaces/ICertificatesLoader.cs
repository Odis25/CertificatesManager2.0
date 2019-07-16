using CertificatesModel.Components;

namespace CertificatesModel.Interfaces
{
    public interface ICertificatesLoader
    {
        /// <summary>
        /// Получить список всех свидетельств из БД
        /// </summary>
        /// <returns></returns>
        Certificates Read();
        
        /// <summary>
        /// Получить список свидетельств соответствующих шаблону
        /// </summary>
        /// <param name="pattern"></param>
        /// <returns></returns>
        Certificates Read(CertificateEventArgs pattern);
        
        /// <summary>
        /// Внести изменения в свидетельство
        /// </summary>
        /// <param name="pattern"></param>
        /// <returns></returns>
        Certificate Update(CertificateEventArgs pattern);

        /// <summary>
        /// Изменить путь к файлам
        /// </summary>
        /// <param name="idArray">Массив id изменяемых свидетельств</param>
        /// <param name="newPath">Новый путь к файлам</param>
        void UpdatePaths(int[] idArray, string newPath);

        /// <summary>
        /// Удаление свидетельств
        /// </summary>
        /// <param name=""></param>
        void Delete(params int[] idList);

        /// <summary>
        /// Добавление в базу нового свидетельства
        /// </summary>
        /// <param name="certificate">Новое свидетельство</param>
        bool Create(Certificate certificate, byte[] byteArray, FileType type);
    }
}
