using RTJuke.Core.Audio;
using RTJuke.Core.Library;
using RTJuke.Core.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RTJuke.Core.Plugins
{
    /// <summary>
    /// Provides information for the music library
    /// and resolves filenames/streams for the RTJuke player
    /// </summary>
    public interface ILibraryProvider : IPlugin
    {                        
        /// <summary>
        /// Scan the library source and signal found songs
        /// </summary>
        /// <param name="clean">true, if all previously aquired information should be discarded</param>
        void Update(IList<Song> existingSongs, IMusicLibraryCallback libraryCallback, IProgressCallback progressCallback);

        /// <summary>
        /// Retrieve an IAudioFile for the given Song (which was created by this LibraryProvider)
        /// </summary>
        /// <param name="song"></param>
        /// <returns></returns>
        IAudioFile RetrieveAudioStream(Song song);

        /// <summary>
        /// Return a custom album art provider, if one should be used with this library provider
        /// </summary>        
        IAlbumArtProvider GetCustomAlbumArtProvider();        
    }    
}
