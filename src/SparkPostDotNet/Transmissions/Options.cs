namespace SparkPostDotNet.Transmissions
{
    using System;
    using Newtonsoft.Json;

    public class Options
    {
        [JsonProperty("start_time")]
        public DateTime? StartTime { get; set; }

        [JsonProperty("open_tracking")]
        public bool OpenTracking { get; set; }

        [JsonProperty("click_tracking")]
        public bool ClickTracking { get; set; }

        [JsonProperty("transactional")]
        public bool Transactional { get; set; }

        [JsonProperty("sandbox")]
        public bool Sandbox { get; set; }

        [JsonProperty("skip_suppression")]
        public bool SkipSupression { get; set; }

        [JsonProperty("ip_pool")]
        public string IpPool { get; set; }

        [JsonProperty("inline_css")]
        public bool InlineCSS { get; set; }
    }
}
