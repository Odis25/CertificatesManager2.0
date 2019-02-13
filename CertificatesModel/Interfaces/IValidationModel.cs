namespace CertificatesModel.Interfaces
{
    public interface IValidationModel
    {
        string ValidateDataModel(Certificate cert);
        string ValidateDataModelForZip(Certificate cert);
    }
}