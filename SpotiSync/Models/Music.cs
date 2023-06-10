namespace SpotiSync.Models
{
    public class Music
    {
        public string Title { get; set; }
        public string AlbumArtist { get; set; }
        public string Album { get; set; }
        public string Genre { get; set; }
        public List<string> Artists { get; set; }
        public int? Year { get; set; }

        public Music(string title, string albumArtist, string album = null, string genre = null, List<string> artists = null, int? year = null)
        {
            Title = title;
            AlbumArtist = albumArtist;
            Album = album;
            Genre = genre;
            Artists = artists;
            Year = year;
        }
    }
}