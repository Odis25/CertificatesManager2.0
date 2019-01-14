﻿using CertificatesModel;
using CertificatesModel.Authorization;
using CertificatesModel.Factories;
using CertificatesModel.UsersModel;
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
        }
    }
}
