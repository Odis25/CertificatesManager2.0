using CertificatesModel.Interfaces;
using CertificatesModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CertificatesModel.Repositories;

namespace CertificatesModel.Factories
{
    public class ModelFactory: BaseFactory
    {
        public ModelFactory()
        {
            Register<ILoader, Loader>();
            //Register<IRepository, Repository>();
        }
    }
}
