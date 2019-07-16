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
            Register<ICertificatePropertiesPanelView<Certificate, Certificates>, CertificatePropertiesPanel>();
            Register<IPreviewPanel<string>, PreviewPanel>();
            Register<IPreviewPanel<byte[]>, PreviewPanel>();
            Register<IAuthorizationPanelView<User>, AuthorizationPanel>();
            Register<IUsersAdministrationPanelView<Users>, UsersAdministrationPanel>();
            Register<ICreateNewView<byte[]>, NewCertificatePanel>();
            Register<ICreateNewActView<Certificates>, CreateActPanel>();
            Register<ITechnicalJournalPanelView<Certificate>, TechnicalJournalPanel>();
        }
    }
}
