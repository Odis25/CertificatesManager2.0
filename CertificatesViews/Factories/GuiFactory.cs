using CertificatesModel;
using CertificatesModel.Factories;
using CertificatesViews.Controls;
using CertificatesViews.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertificatesViews.Factories
{
    public class GuiFactory: BaseFactory
    {
        public GuiFactory()
        {
            Register<IView<Certificates>, CertificatesPanel>();
            Register<IView<Certificate>, CertificatePropertiesPanel>();
            Register<IView<Pages>, PreviewPanel>();
        }
    }
}
