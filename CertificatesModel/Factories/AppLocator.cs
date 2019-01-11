using CertificatesModel.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertificatesModel.Factories
{
    static public class AppLocator
    {
        // Фабрика для классов модели
        public static ModelFactory ModelFactory { get; set; }
    }
}
