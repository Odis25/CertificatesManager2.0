using CertificatesModel;
using CertificatesView.Controls;
using CertificatesView.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertificatesView.Factories
{
    public class GuiFactory: BaseFactory
    {
        public GuiFactory()
        {
            Register<IView<Certificates>, CertificatesPanel>();
        }
    }
}
