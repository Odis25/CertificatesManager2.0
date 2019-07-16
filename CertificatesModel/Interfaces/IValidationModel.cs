namespace CertificatesModel.Interfaces
{
    public interface IValidationModel
    {
        string ValidateDataModel(Certificate cert);
        string ValidateDataModelForFaultNotification(Certificate notification);
    }
}