using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RTJuke.Core.Types;
using System.IO;
using System.Xml.Linq;
using System.Xml;
using RTJuke.Core.Audio;
using RTJuke.Core.Audio.Normalization;
using System.Diagnostics;

namespace RTJuke.Core.Library
{
    /// <summary>
    /// Klasse, die alle zur Verfügung stehenden Titel enthält
    /// </summary>
    public class MusicLibrary : IMusicLibrary
    {
        #region Properties

        List<Song> songs = new List<Song>();

        ILibrarySerializer Serializer { get; set; }
        ILibraryDeserializer Deserializer { get; set; }

        public List<Song> Songs
        {
            get
            {
                return songs;
            }
        }        

        HashSet<Keyword> keywords = new HashSet<Keyword>();

        public HashSet<Keyword> Keywords
        {
            get
            {
                return keywords;
            }
        }
        
        #endregion

        #region Constructor

        public MusicLibrary(ILibrarySerializer serializer, ILibraryDeserializer deserializer)
        {
            Serializer = serializer;
            Deserializer = deserializer;
        }

        #endregion

        #region Events

        /// <summary>
        /// Raised when the library content has changed
        /// </summary>
        public event EventHandler ContentUpdated;

        protected void OnContentUpdated()
        {
            var cu = ContentUpdated;
            if (cu != null)
                cu(this, EventArgs.Empty);
        }

        #endregion

        #region Laden/Speichern

        #region Speichern

        /// <summary>
        /// Speichert die Musikbibliothek in der angegebenen Datei
        /// </summary>
        public void Save()
        {
            Serializer.Write(this);            
        }

        #endregion

        #region Laden

        /// <summary>
        /// Lädt die Musikbibliothek aus der angegebenen Datei
        /// </summary>
        public void Load()
        {
            Deserializer.Read(this);
        }

        #endregion

        #endregion

        #region IMusicLibrary implementation
        public IList<Song> GetSongs()
        {
            return Songs;
        }

        public IList<Song> GetUnplayedSongs()
        {
            return Songs.Where(x => !x.PlayedAlready && !x.IsBlocked).ToList();
        }

        public IList<String> GetGenres()
        {
            // Genres are now saved in the keywords
            return Keywords.Where(x => x.Category == "Genre").Select(x => x.Name).ToList();
        }

        public IList<Keyword> GetKeywords()
        {
            return Keywords.ToList();
        }        

        public void RequestRebuild()
        {
            // update keywords
            Keywords.Clear();
            foreach (var c in Songs.SelectMany(x => x.Keywords).Distinct())
                Keywords.Add(c);

            songs = Songs.OrderBy(x => x.Artist).ThenBy(x => x.Album).ThenBy(x => x.Track).ThenBy(x => x.Title).ToList();

            OnContentUpdated();
        }

        public IList<Song> Find(string searchText)
        {
            throw new NotImplementedException();
        }
        #endregion    
    }
}
