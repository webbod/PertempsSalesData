using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Pertemps.Concrete.Interfaces;
using Pertemps.ConcreteModels;
using Pertemps.Models.QueryParameters;
using Pertemps.Web.Models;


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
            CacheQueryParams(queryParams);

            var results = DataService.SalesData.GetSalesSummary(queryParams);

            var model = new SalesSummaryViewModel("/Analytics/Report/SalesData/", queryParams, results);

            return View("Index", model);
        }

        public IActionResult Report(SalesQueryParameters queryParams)
        {
            return Index(queryParams);
        }

        public IActionResult ByRegion()
        {
            var model = GetPickerModel();
            return View(model);
        }

        public IActionResult ByCountry()
        {
            var model = GetPickerModel();
            return View(model);
        }

        public IActionResult ByPeriod()
        {
            var model = GetPickerModel();
            return View(model);
        }

    }
}