using System.Collections.Generic;

namespace SparkPostDotNet.Transmissions
{
    using Newtonsoft.Json;

    [JsonObject(MemberSerialization.OptOut)]
    public class Recipient
    {
        public Recipient()
        {
            this.Address = new Address();
        }

        [JsonProperty("address")]
        public Address Address { get; set; }

        [JsonProperty("substitution_data")]
        public Dictionary<string, object> SubstitutionData { get; set; }
    }
}
