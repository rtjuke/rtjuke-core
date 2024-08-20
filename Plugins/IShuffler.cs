using RTJuke.Core.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTJuke.Core.Plugins
{
    /// <summary>
    /// Interface for plugin which offer a distinct shuffle logic for
    /// selecting the next song.
    /// Can be instantiated many times during runtime (with different settings)
    /// </summary>
    public interface IShuffler : IPlugin
    {
        /// <summary>
        /// Return a new song from the shuffle logic
        /// </summary>
        /// <param name="enqueuedSongs">The songs which are currently enqueued and should not be selected</param>        
        /// <returns>A randomly selected song based on the shuffle logic</returns>
        Song Next(IReadOnlyList<Song> enqueuedSongs);        
    }
}
