using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.DTOs.Import
{
    [JsonObject]
    public class CarDto
    {
        [JsonProperty("make")]
        public string Make { get; set; } = null!;
        [JsonProperty("model")]
        public string Model { get; set; } = null!;
        [JsonProperty("traveledDistance")]
        public long TravelledDistance { get; set; }
        [JsonProperty("partsId")]
        public List<int> PartsId { get; set; }
    }
}
