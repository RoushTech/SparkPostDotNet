namespace SparkPostDotNet.Transmissions
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.IO;
    using System.Net;
    using System.Threading.Tasks;
    using System.Text;
    
    [JsonObject(MemberSerialization.OptIn)]
    public class Transmission : HttpContent
    {
        public Transmission()
        {
            this.Options = new Options();
            this.Metadata = new Dictionary<string, object>();
            this.SubstitutionData = new Dictionary<string, string>();
            this.Content = new Content();
            this.Recipients = new List<Recipient>();
        }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("options")]
        public Options Options { get; set; }

        [JsonProperty("recipients")]
        public IList<Recipient> Recipients { get; set; }

        [JsonProperty("campaign_id")]
        public string CampaignId { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("metadata")]
        public Dictionary<string, object> Metadata { get; set; }

        [JsonProperty("substitution_data")]
        public Dictionary<string, string> SubstitutionData { get; set; }

        [JsonProperty("return_path")]
        public string ReturnPath { get; set; }

        [JsonProperty("content")]
        public Content Content { get; set; }

        [JsonProperty("total_recipients")]
        public int TotalRecipients { get; set; }

        [JsonProperty("num_generated")]
        public int NumberGenerated { get; set; }

        [JsonProperty("num_failed_generation")]
        public int NumberFailedGeneration { get; set; }

        [JsonProperty("num_invalid_recipients")]
        public int NumberFailedRecipients { get; set; }
        
        protected async override Task SerializeToStreamAsync(Stream stream, TransportContext context)
        {
            var content = GetContent();
            await stream.WriteAsync(content, 0, content.Length);
        }

        protected override bool TryComputeLength(out long length)
        {
            length = GetContent().Length;
            return true;
        }

        protected byte[] GetContent()
        {
            return Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(this));
        }
    }
}
