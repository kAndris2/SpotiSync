using SpotiSync.Misc;

namespace SpotiSync.Services
{
    public class LocalMusicHandler
    {
        public string MusicFolderPath { get; }

        public LocalMusicHandler()
        {
            MusicFolderPath = GetMusicFolderPath();
        }

        private void CollectMusic()
        {

        }

        private string GetMusicFolderPath()
        {
            Console.WriteLine("Please give me a folder to your music.");
            return new DialogBox().FolderBrowser();
        }
    }
}