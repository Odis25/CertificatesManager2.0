using CertificatesModel;
using CertificatesModel.Domain.UsersModel;
using CertificatesModel.Factories;
using CertificatesViews.Controls;
using CertificatesViews.Interfaces;

namespace CertificatesViews.Factories
{
    public class GuiFactory : BaseFactory
    {
        public GuiFactory()
        {
            Register<IView<Certificates>, CertificatesPanel>();
            Register<IViewAndEdit<Certificate>, CertificatePropertiesPanel>();
            Register<IView<string>, PreviewPanel>();
            Register<IView<User>, AuthorizationPanel>();
            Register<IView<Users>, UsersAdministrationPanel>();
        }
    }
}
