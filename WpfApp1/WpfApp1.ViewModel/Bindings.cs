using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using WpfApp1.Helpers;

namespace WpfApp1.ViewModel
{
    class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind<Ihelper>().To<helper>();
        }
    }
}
