namespace SparkPostDotNet.Transmissions
{
    using Newtonsoft.Json;

    public class Recipient
    {
        public Recipient()
        {
            this.Address = new Address();
        }

        [JsonProperty("address")]
        public Address Address { get; set; }
    }
}
