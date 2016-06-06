# SparkPostDotNet

SparkPost support for your .NET Core projects.

# Using in .NET Core


Place the following in your Startup.ConfigureServices section:

``` csharp
services.AddSparkPost();
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