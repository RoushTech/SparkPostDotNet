# SparkPostDotNet

SparkPost support for your .NET Core projects.

# Using in .NET Core


Place the following in your Startup.ConfigureServices section:

``` csharp
services.AddSparkPost();
```

Hook up the configuration using the following code:

``` csharp
services.AddOptions(); // Most apps already are using this, but just in case.
services.Configure<SparkPostOptions>(options => Configuration.GetSection("SparkPost").Bind(options));
```

Configure SparkPost from your appSettings.json file like so:

``` javascript
  "SparkPost": {
    "ApiKey": "[Api key here]"
  }
```

# Sending an e-mail

``` csharp
var transmission = new Transmission();
transmission.Content.From.EMail = "noreply@mydomain.com";
transmission.Content.From.Name = "NoReply Friendly Name";
transmission.Content.Subject = "My Subject Here";
transmission.Content.Html = "<h1>Hello There</h1>";
var recipient = new Recipient();
recipient.Address.EMail = "recipient@mydomain.com";
transmission.Recipients.Add(recipient);
await this.SparkPostClient.CreateTransmission(transmission);
```

# Testing

You'll need to configure the following environment variables:

 * SPARKPOST_APIKEY - SparkPost API key for testing.
 * SPARKPOST_SENDINGDOMAIN - Domain we're sending from/to.