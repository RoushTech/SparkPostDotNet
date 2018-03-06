namespace SparkPostDotNet.Transmissions
{
    using Newtonsoft.Json;

    public class Address
    {
        [JsonProperty("email")]
        public string EMail { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}