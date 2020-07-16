using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Pertemps.Concrete.Interfaces;
using Pertemps.ConcreteModels;
using System;

namespace Pertemps.Web.Controllers
{
    public class ABaseController : Controller
    {
        private readonly DatabaseOptions _DatabaseOptions;
        protected IIsAPertempsDataService DataService;

        public ABaseController( 
            IIsAPertempsDataService dataService,
            IOptions<DatabaseOptions> databaseOptions)
        {
            _DatabaseOptions = databaseOptions.Value;
            DataService = dataService;

            DataService.Initalise(_DatabaseOptions);
        }
    }
}
