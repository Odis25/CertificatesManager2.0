﻿using CertificatesModel;
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
            Register<IPreView<string>, PreviewPanel>();
            Register<IView<User>, AuthorizationPanel>();
            Register<IView<Users>, UsersAdministrationPanel>();

            Register<ICreateNewView<byte[]>, NewCertificatePanel>();
            Register<IPreView<byte[]>, PreviewPanel>();
            Register<ICreateNewTransferDocumentView<Certificates>, CreateActPanel>();
        }
    }
}
