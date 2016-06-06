namespace SparkPostDotNet.Transmissions
{
    using Newtonsoft.Json;

    public class Address
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("email")]
        public string EMail { get; set; }
    }
}
