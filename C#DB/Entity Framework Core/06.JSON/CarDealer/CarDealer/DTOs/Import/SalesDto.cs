using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.DTOs.Import
{
    [JsonObject]
    public class SalesDto
    {
        [JsonProperty("carId")]
        public int CarId { get; set; }
        [JsonProperty("customerId")]
        public int CustomerId { get; set; }
        [JsonProperty("discount")]
        public decimal Discount { get; set; }
    }
}
