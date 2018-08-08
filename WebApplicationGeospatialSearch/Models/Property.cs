using Microsoft.Azure.Documents.Spatial;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationGeospatialSearch.Models
{
    public class Property
    {
        [JsonProperty("idPropertySearch")]
        public string IdPropertySearch { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("value")]
        public int Value { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("contactName")]
        public string ContactName { get; set; }

        [JsonProperty("contactEmail")]
        public object ContactEmail { get; set; }

        [JsonProperty("contactPhone")]
        public string ContactPhone { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("operation")]
        public string Operation { get; set; }

        [JsonProperty("rooms")]
        public int Rooms { get; set; }

        [JsonProperty("restrooms")]
        public int Restrooms { get; set; }

        [JsonProperty("Ground")]
        public int ground { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("location")]
        public Point Location { get; set; }

        [JsonProperty("id")]
        public string Id { get => this.IdPropertySearch; set => this.IdPropertySearch = value; }

        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }
    }
}
