using System.Collections;

namespace Lab9_10CSharpT
{
    public class MusicManager
    {
        public static void Task()
        {
            MusicCatalog catalog = new();

            var disc1 = new MusicDisc("Rock Collection");
            var disc2 = new MusicDisc("Pop Vibes");

            catalog.AddDisc(disc1);
            catalog.AddDisc(disc2);

            catalog.AddSongToDisc("Rock Collection", new Song("Bohemian Rhapsody", "Queen", TimeSpan.FromSeconds(354)));
            catalog.AddSongToDisc("Rock Collection", new Song("Dream On", "Aerosmith", TimeSpan.FromSeconds(270)));

            catalog.AddSongToDisc("Pop Vibes", new Song("Blinding Lights", "The Weeknd", TimeSpan.FromSeconds(200)));
            catalog.AddSongToDisc("Pop Vibes", new Song("Levitating", "Dua Lipa", TimeSpan.FromSeconds(203)));

            Console.WriteLine("Catalog:");
            catalog.ViewCatalog();

            Console.WriteLine("Pop Vibes disc:");
            catalog.ViewDisc("Pop Vibes");

            Console.WriteLine("\nSearch for artist: The Weeknd");
            catalog.SearchByArtist("The Weeknd");

            catalog.RemoveSongFromDisc("Pop Vibes", "Levitating");

            Console.WriteLine("\nAfter removing the song 'Levitating'");
            catalog.ViewDisc("Pop Vibes");

            catalog.RemoveDisc("Rock Collection");

            Console.WriteLine("\nAfter removing the disc 'Rock Collection'");
            catalog.ViewCatalog();
        }
    }

    class Song
    {
        public string Title { get; set; }
        public string Artist { get; set; }
        public TimeSpan Duration { get; set; }

        public Song(string title, string artist, TimeSpan duration)
        {
            Title = title;
            Artist = artist;
            Duration = duration;
        }

        public override string ToString()
        {
            return $"{Title} - {Artist} ({Duration:mm\\:ss})";
        }
    }

    class MusicDisc
    {
        public string Name { get; set; }
        public List<Song> Songs { get; set; }

        public MusicDisc(string name)
        {
            Name = name;
            Songs = new List<Song>();
        }

        public void AddSong(Song song) => Songs.Add(song);

        public void RemoveSong(string title) => Songs.RemoveAll(s => s.Title == title);

        public override string ToString()
        {
            string result = $"Disc: {Name}\n";
            foreach (var song in Songs)
                result += "  " + song + "\n";

            return result;
        }
    }

    class MusicCatalog
    {
        private readonly Hashtable catalog = new();

        public void AddDisc(MusicDisc disc)
        {
            if (!catalog.ContainsKey(disc.Name))
                catalog[disc.Name] = disc;
        }

        public void RemoveDisc(string discName)
        {
            catalog.Remove(discName);
        }

        public void AddSongToDisc(string discName, Song song)
        {
            if (catalog[discName] is MusicDisc disc)
                disc.AddSong(song);
        }

        public void RemoveSongFromDisc(string discName, string songTitle)
        {
            if (catalog[discName] is MusicDisc disc)
                disc.RemoveSong(songTitle);
        }

        public void ViewCatalog()
        {
            foreach (DictionaryEntry entry in catalog)
                if (entry.Value is MusicDisc disc)
                    Console.WriteLine(disc);
        }

        public void ViewDisc(string discName)
        {
            if (catalog[discName] is MusicDisc disc)
                Console.WriteLine(disc);
            else
                Console.WriteLine($"Disc '{discName}' not found.");
        }

        public void SearchByArtist(string artist)
        {
            Console.WriteLine($"Searching songs by artist: {artist}");
            foreach (DictionaryEntry entry in catalog)
            {
                if (entry.Value is not MusicDisc disc) continue;

                foreach (var song in disc.Songs)
                    if (song.Artist.Equals(artist, StringComparison.OrdinalIgnoreCase))
                        Console.WriteLine($"{disc.Name}: {song}");
            }
        }
    }
}
