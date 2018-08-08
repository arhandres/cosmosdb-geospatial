using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationGeospatialSearch.Models
{
    public class LocationSearchModel
    {
        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public double Radius { get; set; }
    }
}
