using SpotiSync.Services;

namespace SpotiSync
{
    static class Program
    {
        [STAThread]
        public static void Main()
        {
            new SpotifyConnector().Connect();
        }
    }
}