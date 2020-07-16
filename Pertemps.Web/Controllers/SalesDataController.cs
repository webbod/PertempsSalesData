using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Pertemps.Concrete.Interfaces;
using Pertemps.ConcreteModels;
using Pertemps.Models.QueryParameters;

namespace Pertemps.Web.Controllers
{
    public class SalesDataController : ABaseController
    {
        public SalesDataController(IIsAPertempsDataService dataService, IOptions<DatabaseOptions> databaseOptions) : 
            base(dataService, databaseOptions)
        {
        }

        public IActionResult Index(SalesQueryParameters queryParams)
        {
            var results = DataService.SalesData.GetSalesSummary(queryParams);
            
            ViewData.Add("QueryParams", queryParams);
            return View("Index");
        }

        public IActionResult Report(SalesQueryParameters queryParams)
        {
            return Index(queryParams);
        }
    }
}