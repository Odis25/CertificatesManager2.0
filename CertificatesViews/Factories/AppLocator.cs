using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertificatesView.Factories
{
    static public class AppLocator
    {
        // Фабрика для классов модели
        public static BaseFactory ModelFactory { get; set; }
        // Фабрика для классов представления
        public static BaseFactory GuiFactory { get; set; }

    }
}
