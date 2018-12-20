using CertificatesModel;
using CertificatesModel.Factories;
using CertificatesViews.Controls;
using CertificatesViews.Interfaces;

namespace CertificatesViews.Factories
{
    public class GuiFactory: BaseFactory
    {
        public GuiFactory()
        {
            Register<IView<Certificates>, CertificatesPanel>();
            Register<IView<Certificate>, CertificatePropertiesPanel>();
            Register<IView<string>, PreviewPanel>();
        }
    }
}
