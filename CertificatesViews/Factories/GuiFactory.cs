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
            Register<IDetailsView<Certificate, Certificates>, CertificatePropertiesPanel>();
            Register<IView<string>, PreviewPanel>();
            Register<IView<User>, AuthorizationPanel>();
            Register<IView<Users>, UsersAdministrationPanel>();

            Register<ICreateNewView<byte[]>, NewCertificatePanel>();
            Register<IView<byte[]>, PreviewPanel>();
            Register<ICreateNewTransferDocumentView<Certificates>, CreateActPanel>();
        }
    }
}
