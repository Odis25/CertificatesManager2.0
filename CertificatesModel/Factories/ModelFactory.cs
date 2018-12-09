using CertificatesModel.Interfaces;
using CertificatesModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertificatesView.Factories
{
    public class ModelFactory: BaseFactory
    {
        public ModelFactory()
        {
            Register<ILoader, Loader>();
        }
    }
}
