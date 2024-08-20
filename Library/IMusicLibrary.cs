using RTJuke.Core.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTJuke.Core.Library
{
    /// <summary>
    /// Interface to access the music library
    /// </summary>
    public interface IMusicLibrary
    {
        IList<Song> GetSongs();

        IList<Keyword> GetKeywords();

        IList<String> GetGenres();

        IList<Song> GetUnplayedSongs();

        IList<Song> Find(string searchText);

        /// <summary>
        /// Refresh the library cache and vailable genres and categories
        /// </summary>
        void RequestRebuild();

        void Save();

        void Load();

        /// <summary>
        /// Raised when the library content has changed
        /// </summary>
        event EventHandler ContentUpdated;
    }
}
