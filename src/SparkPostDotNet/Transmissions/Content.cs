namespace SparkPostDotNet.Transmissions
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class Content
    {
        [JsonProperty("attachments")]
        public IList<Attachment> Attachments { get; set; }

        [JsonProperty("from")]
        public Address From { get; set; }

        [JsonProperty("headers")]
        public object Headers { get; set; }

        [JsonProperty("html")]
        public string Html { get; set; }

        [JsonProperty("inline_images")]
        public IList<Attachment> InlineImages { get; set; }

        [JsonProperty("reply_to")]
        public string ReplyTo { get; set; }

        [JsonProperty("subject")]
        public string Subject { get; set; }

        [JsonProperty("template_id")]
        public string TemplateId { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        public Content()
        {
            this.From = new Address();
            this.Attachments = new List<Attachment>();
            this.InlineImages = new List<Attachment>();
        }
    }
}