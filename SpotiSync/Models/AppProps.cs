using System.Text.RegularExpressions;

namespace SpotiSync.Models
{
    public class AppProps
    {
        public string ClientId { get; }
        public string ClientSecret { get; }
        public string RedirectUrl { get; }
        public int Port { get; private set; }

        public AppProps(string clientId, string clientSecret, string redirectUrl)
        {
            ClientId = clientId;
            ClientSecret = clientSecret;
            RedirectUrl = redirectUrl;
            Port = GetPortFromUrl(redirectUrl);
        }

        private int GetPortFromUrl(string url)
        {
            return Int32.Parse(Regex.Match(url, @"\d+").Value);
        }
    }
}