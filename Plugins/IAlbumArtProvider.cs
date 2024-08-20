using RTJuke.Core.Types;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTJuke.Core.Plugins
{
    /// <summary>
    /// Interface for classes which provide album arts
    /// </summary>
    public interface IAlbumArtProvider
    {
        /// <summary>
        /// Get a uri which points to the image data of the album art for the given song        
        /// </summary>        
        Task<Uri> GetAlbumArtAsync(Song song);

        /// <summary>
        /// Get a uri which points to an image of artist art for teh artist of the given song
        /// </summary>
        Task<Uri> GetArtistArtAsync(Song song);
    }

    /// <summary>
    /// A plugin which contains one or more AlbumArtProviders
    /// </summary>
    public interface IAlbumArtPlugin : IPlugin
    {
        IEnumerable<IAlbumArtProvider> GetAlbumArtProviders();
    }
}
