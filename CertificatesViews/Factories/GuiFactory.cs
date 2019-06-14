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
            Register<ICertificatePanelView<Certificates>, CertificatesPanel>();
            Register<IDetailsView<Certificate, Certificates>, CertificatePropertiesPanel>();
            Register<IPreView<string>, PreviewPanel>();
            Register<IView<User>, AuthorizationPanel>();
            Register<IView<Users>, UsersAdministrationPanel>();

            Register<ICreateNewView<byte[]>, NewCertificatePanel>();
            Register<IPreView<byte[]>, PreviewPanel>();
            Register<ICreateNewActView<Certificates>, CreateActPanel>();

            Register<IView<Certificate>, TechnicalJournalPanel>();
        }
    }
}
