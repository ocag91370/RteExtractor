using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RteExtractor.Ecowatt
{
    public class EcowattData
    {
        [JsonPropertyName("signals")]
        public List<DaySignals> Signals { get; set; }
    }
}
