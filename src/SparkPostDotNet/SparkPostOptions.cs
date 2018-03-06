namespace SparkPostDotNet
{
    public class SparkPostOptions
    {
        /// <summary>
        ///     An optional host uri. If none is provided, the default of 'https://api.sparkpost.com/api/v1/transmissions' is used.
        /// </summary>
        public string ApiHostUri { get; set; }

        public string ApiKey { get; set; }
    }
}