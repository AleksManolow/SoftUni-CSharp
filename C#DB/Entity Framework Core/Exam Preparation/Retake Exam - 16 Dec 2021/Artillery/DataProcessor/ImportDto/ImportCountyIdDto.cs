using Newtonsoft.Json;

namespace Artillery.DataProcessor.ImportDto
{
    [JsonObject]
    public class ImportCountyIdDto
    {
        [JsonProperty("Id")]
        public int Id { get; set; }
    }
}
