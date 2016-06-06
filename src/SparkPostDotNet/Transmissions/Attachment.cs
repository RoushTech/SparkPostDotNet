namespace SparkPostDotNet.Transmissions
{
    using Newtonsoft.Json;
    using System;

    [JsonObject(MemberSerialization.OptIn)]
    public class Attachment
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("data")]
        public string DataString { get { return Convert.ToBase64String(this.Data); } }

        public byte[] Data { get; set; }
    }
}
