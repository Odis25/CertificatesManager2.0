using CertificatesModel.Interfaces;

namespace CertificatesModel.Factories
{
    public class ModelFactory: BaseFactory
    {
        public ModelFactory()
        {
            Register<ILoader, CertificatesLoader>();
        }
    }
}
