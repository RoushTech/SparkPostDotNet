namespace SparkPostDotNet
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Options;
    using Transmissions;

    public class SparkPostClient
    {
        private const string DefaultUri = "https://api.sparkpost.com/api/v1/transmissions";

        protected SparkPostOptions Options { get; }

        protected Uri SparkPostUri =>
            new Uri(string.IsNullOrEmpty(this.Options.ApiHostUri) ? DefaultUri : this.Options.ApiHostUri);

        public SparkPostClient(IOptions<SparkPostOptions> options)
        {
            this.Options = options.Value;
        }

        public async Task CreateTransmission(Transmission transmission)
        {
            if (string.IsNullOrEmpty(this.Options.ApiKey))
            {
                throw new InvalidOperationException("Configuration variable SparkPost:ApiKey must be set.");
            }

            using (var httpClient = new HttpClient())
            {
                transmission.Headers.Clear();
                transmission.Headers.Add("Content-Type", "application/json");
                httpClient.DefaultRequestHeaders.Add("Authorization", this.Options.ApiKey);
                var response = await httpClient.PostAsync(this.SparkPostUri, transmission);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(await response.Content.ReadAsStringAsync());
                }
            }
        }
    }
}