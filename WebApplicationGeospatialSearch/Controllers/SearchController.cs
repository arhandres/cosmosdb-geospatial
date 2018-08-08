using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Documents.Spatial;
using WebApplicationGeospatialSearch.Models;

namespace WebApplicationGeospatialSearch.Controllers
{
    public class SearchController : Controller
    {
        public async Task<IActionResult> SearchByLocation(LocationSearchModel model)
        {
            var result = await DocumentDBRepository<Property>.GetItemsAsync(p => p.Location.Distance(new Point(model.Longitude, model.Latitude)) < model.Radius);

            return Json(result);
        }
    }
}