using SpotifyAPI.Web;

namespace SpotiSync.Services
{
    public class SpotifyHandler
    {
        private readonly SpotifyClient _client;
        private readonly LocalMusicHandler _musicHandler;

        public SpotifyHandler(SpotifyClient client)
        {
            _client = client;
            _musicHandler = new();
        }
    }
}