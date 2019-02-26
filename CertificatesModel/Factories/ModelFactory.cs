using CertificatesModel.Interfaces;
using CertificatesModel.ScannerService;
using CertificatesModel.Validation;

namespace CertificatesModel.Factories
{
    public class ModelFactory: BaseFactory
    {
        public ModelFactory()
        {
            Register<ICertificatesLoader, CertificatesLoader>();
            Register<IUsersLoader, UsersLoader>();
            Register<IScanner, Scanner>();
            Register<IValidationModel, ValidationModel>();
        }
    }
}
