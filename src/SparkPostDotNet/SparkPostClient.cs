namespace SparkPostDotNet
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Transmissions;
    using Microsoft.Extensions.Options;

    public class SparkPostClient
    {
        public SparkPostClient(IOptions<SparkPostOptions> options)
        {
            this.Options = options.Value;
        }

        protected SparkPostOptions Options { get; set; }

        protected Uri SparkPoostUri {  get { return new Uri("https://api.sparkpost.com/api/v1/transmissions"); } }

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
                var response = await httpClient.PostAsync(this.SparkPoostUri, transmission);
                if(!response.IsSuccessStatusCode)
                {
                    throw new Exception(await response.Content.ReadAsStringAsync());
                }
            }
        }
    }
}
