namespace SparkPostDotNet.Transmissions
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class Content
    {
        public Content()
        {
            this.From = new Address();
            this.Attachments = new List<Attachment>();
            this.InlineImages = new List<Attachment>();
        }

        [JsonProperty("html")]
        public string Html { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("subject")]
        public string Subject { get; set; }

        [JsonProperty("from")]
        public Address From { get; set; }

        [JsonProperty("headers")]
        public object Headers { get; set; }

        [JsonProperty("attachments")]
        public IList<Attachment> Attachments { get; set; }

        [JsonProperty("inline_images")]
        public IList<Attachment> InlineImages { get; set; }
    }
}
