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
            Register<ICertificatesView<Certificates>, CertificatesPanel>();
            Register<ICertificatePropertiesView<Certificate, Certificates>, CertificatePropertiesPanel>();
            Register<IPreviewView<string>, PreviewPanel>();
            Register<IPreviewView<byte[]>, PreviewPanel>();
            Register<IAuthorizationView<User>, AuthorizationPanel>();
            Register<IUsersManagementView<Users>, UsersManagementPanel>();
            Register<INewCertificateView<byte[]>, NewCertificatePanel>();
            Register<ICreateActView<Certificates>, CreateActPanel>();
            Register<ITechnicalJournalView<Certificate>, TechnicalJournalPanel>();
        }
    }
}
