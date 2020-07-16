using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pertemps.Web.Controllers
{
    public class ABaseController
    {
        IServiceProvider ServiceProvider;

        public ABaseController(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }
    }
}
