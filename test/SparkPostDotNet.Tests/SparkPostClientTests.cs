namespace SparkPostDotNet.Tests
{
    using System;
    using System.Threading.Tasks;
    using Transmissions;
    using Xunit;
    using Options = Microsoft.Extensions.Options.Options;

    public class SparkPostClientTests
    {
        public SparkPostClientTests()
        {
            var options = new SparkPostOptions
            {
                ApiKey = Environment.GetEnvironmentVariable("SPARKPOST_APIKEY")
            };
            this.Client = new SparkPostClient(Options.Create(options));
            this.SendingDomain = Environment.GetEnvironmentVariable("SPARKPOST_SENDINGDOMAIN");
        }

        protected SparkPostClient Client { get; set; }

        protected string SendingDomain { get; set; }

        [Fact]
        public async Task SendBasicEmail()
        {
            var transmission = new Transmission();
            transmission.Content.From.EMail = $"testing@{this.SendingDomain}";
            transmission.Content.From.Name = "Testing";
            transmission.Content.Subject = "Test Subject Here";
            transmission.Content.Html = "<h1>Test body here</h1>";
            transmission.CampaignId = "automated-testing";
            var recipient = new Recipient();
            recipient.Address.EMail = $"testrecipient@{this.SendingDomain}";
            transmission.Recipients.Add(recipient);
            await this.Client.CreateTransmission(transmission);
        }
    }
}