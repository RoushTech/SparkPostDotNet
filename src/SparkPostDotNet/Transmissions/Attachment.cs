namespace SparkPostDotNet.Transmissions
{
    using System;
    using Newtonsoft.Json;

    [JsonObject(MemberSerialization.OptIn)]
    public class Attachment
    {
        public byte[] Data { get; set; }

        [JsonProperty("data")]
        public string DataString => Convert.ToBase64String(this.Data);

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}