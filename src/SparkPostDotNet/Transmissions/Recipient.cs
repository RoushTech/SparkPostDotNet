namespace SparkPostDotNet.Transmissions
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    [JsonObject(MemberSerialization.OptOut)]
    public class Recipient
    {
        [JsonProperty("address")]
        public Address Address { get; set; }

        [JsonProperty("substitution_data")]
        public Dictionary<string, object> SubstitutionData { get; set; }

        public Recipient()
        {
            this.Address = new Address();
        }
    }
}