using NetOffice.OutlookApi;
using NetOffice.OutlookApi.Enums;

namespace CertificatesModel.MailService
{
    public static class MailService
    {
        /// <summary>
        /// отправка файлов по e-mail с помощью Microsoft Outlook
        /// </summary>
        /// <param name="filePaths"></param>
        public static void SendFilesByEmail(string[] filePaths)
        {
            var objOutlook = new Application();
            var mailItem = (MailItem)(objOutlook.CreateItem(OlItemType.olMailItem));
            mailItem.Subject = "";
            mailItem.HTMLBody = "";
            mailItem.Display(mailItem);
            foreach (string path in filePaths)
            {
                mailItem.Attachments.Add(path);
            }
        }
    }
}
