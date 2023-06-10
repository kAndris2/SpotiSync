using System.Configuration;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Auth;
using SpotiSync.Models;

namespace SpotiSync.Services
{
    public class SpotifyConnector
    {
        private readonly AppProps _appProps;
        private EmbedIOAuthServer _server;

        public SpotifyConnector()
        {
            _appProps = GetAppProps();
        }

        public async Task Connect()
        {
            _server = new EmbedIOAuthServer(new Uri(_appProps.RedirectUrl), _appProps.Port);
            await _server.Start();

            _server.AuthorizationCodeReceived += OnAuthorizationCodeReceived;
            _server.ErrorReceived += OnErrorReceived;

            var request = new LoginRequest(_server.BaseUri, _appProps.ClientId, LoginRequest.ResponseType.Code)
            {
                Scope = new List<string>
                {
                    Scopes.UserReadEmail,
                    Scopes.PlaylistModifyPrivate,
                    Scopes.PlaylistReadPrivate,
                    Scopes.UserLibraryModify,
                    Scopes.UserLibraryRead
                }
            };
            BrowserUtil.Open(request.ToUri());
            _ = Console.ReadKey();
        }

        private async Task OnAuthorizationCodeReceived(object sender, AuthorizationCodeResponse response)
        {
            await _server.Stop();

            var config = SpotifyClientConfig.CreateDefault();
            var tokenResponse = await new OAuthClient(config).RequestToken(
              new AuthorizationCodeTokenRequest(
                _appProps.ClientId, _appProps.ClientSecret, response.Code, new Uri(_appProps.RedirectUrl)
              )
            );

            var spotify = new SpotifyClient(tokenResponse.AccessToken);
        }

        private async Task OnErrorReceived(object sender, string error, string state)
        {
            Console.WriteLine($"Aborting authorization, error received: {error}");
            await _server.Stop();
        }

        private AppProps GetAppProps()
        {
            return new
            (
                ConfigurationManager.AppSettings["clientId"],
                ConfigurationManager.AppSettings["clientSecret"],
                ConfigurationManager.AppSettings["redirectUrl"]
            );
        }
    }
}