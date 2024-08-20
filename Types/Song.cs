using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RTJuke.Core.Audio.Normalization;

namespace RTJuke.Core.Types
{
    /// <summary>
    /// A song from the MusicLibrary
    /// </summary>
    public class Song
    {
        /// <summary>
        /// Die Audiodatei an sich
        /// </summary>
        public String Url { get; set; }

        /// <summary>
        /// Bereits gespielt?
        /// </summary>
        public bool PlayedAlready { get; set; }

        /// <summary>
        /// Don't select this title from shuffle for the current session
        /// </summary>
        public bool IsBlocked { get; set; }

        /// <summary>
        /// Titelnummer
        /// </summary>
        public String Track { get; set; }

        /// <summary>
        /// Liedtitel
        /// </summary>
        public String Title { get; set; }

        /// <summary>
        /// Interpret
        /// </summary>
        public String Artist { get; set; }

        /// <summary>
        /// Name des Albums
        /// </summary>
        public String Album { get; set; }        

        /// <summary>
        /// Keywords of a song (e.g. genres, categories, moods)
        /// </summary>
        public HashSet<Keyword> Keywords { get; private set; }

        /// <summary>
        /// return a list of categories with keywords in braces
        /// e.g. Genre - Rock, Blues, Mood - Aggresive
        /// </summary>
        public String KeywordDisplayText
        {
            get
            {                
                return String.Join(", ", Keywords.GroupBy(x => x.Category).Select(c => c.Key + " - " + String.Join(", ", c.Select(y => y.Name))));                
            }
        }

        /// <summary>
        /// Die Länge des Titels in Sekunden
        /// </summary>
        public TimeSpan Length { get; set; }

        /// <summary>
        /// The available normalization information for this song, if any
        /// </summary>
        public NormalizationInfo NormalizationInfo { get; set; }

        /// <summary>
        /// The ID of the provider plugin which added
        /// this Song to the music library
        /// </summary>
        public string ProviderId { get; set; }

        /// <summary>
        /// Data needed by the provider plugin to retrieve
        /// the file stream info at runtime
        /// </summary>
        public string ProviderData { get; set; }

        public Song()
        {
            PlayedAlready = false;
            IsBlocked = false;

            Url = "";
            Track = "";
            Title = "";
            Artist = "";
            Album = "";
            ProviderId = "";
            ProviderData = "";
            
            Keywords = new HashSet<Keyword>();
        }

        public override string ToString()
        {
            return (Artist ?? "<unknown artist>") + " - " + (Title ?? "<unknown title>");
        }
    }
}
