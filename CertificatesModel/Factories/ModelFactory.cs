using CertificatesModel.Interfaces;

namespace CertificatesModel.Factories
{
    public class ModelFactory: BaseFactory
    {
        public ModelFactory()
        {
            Register<ICertificatesLoader, CertificatesLoader>();
            Register<IUsersLoader, UsersLoader>();
        }
    }
}
