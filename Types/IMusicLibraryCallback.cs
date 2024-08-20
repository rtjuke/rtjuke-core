using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTJuke.Core.Types
{
    /// <summary>
    /// Callback interface which provides access to the music library to plugins
    /// </summary>
    public interface IMusicLibraryCallback
    {
        /// <summary>
        /// Try to add the given song to the library
        /// </summary>
        /// <param name="song"></param>
        /// <returns></returns>
        bool AddSong(Song song);        

        /// <summary>
        /// Removes the given song from the library
        /// (for example if the file has been deleted)
        /// </summary>
        /// <param name="song"></param>
        /// <returns></returns>
        bool RemoveSong(Song song);

        /// <summary>
        /// Signal to the library that the data of this song has been changed
        /// (e.g. ID3-Tags were changed and have been re-read)
        /// </summary>
        /// <param name="song"></param>
        /// <returns></returns>
        bool UpdateSong(Song song);        
    }
}
