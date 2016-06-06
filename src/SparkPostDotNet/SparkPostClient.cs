namespace SparkPostDotNet
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Configuration;
    using Transmissions;

    public class SparkPostClient
    {
        public SparkPostClient(IConfigurationRoot configuration)
        {
            this.Configuration = configuration;
        }

        protected IConfigurationRoot Configuration { get; set; }

        protected Uri SparkPoostUri {  get { return new Uri("https://api.sparkpost.com/api/v1/transmissions"); } }

        public async Task CreateTransmission(Transmission transmission)
        {
            var apiKey = this.Configuration["SparkPost:ApiKey"];
            if (string.IsNullOrEmpty(apiKey))
            {
                throw new InvalidOperationException("Configuration variable SparkPost:ApiKey must be set.");
            }

            using (var httpClient = new HttpClient())
            {
                transmission.Headers.Clear();
                transmission.Headers.Add("Content-Type", "application/json");
                httpClient.DefaultRequestHeaders.Add("Authorization", apiKey);
                var response = await httpClient.PostAsync(this.SparkPoostUri, transmission);
                if(!response.IsSuccessStatusCode)
                {
                    throw new Exception(await response.Content.ReadAsStringAsync());
                }
            }
        }
    }
}
