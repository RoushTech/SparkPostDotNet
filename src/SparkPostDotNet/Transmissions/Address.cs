namespace SparkPostDotNet.Transmissions
{
    using Newtonsoft.Json;

    public class Address
    {
        [JsonProperty("email")]
        public string EMail { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("header_to")]
        public string HeaderTo { get; set; }
    }
}
