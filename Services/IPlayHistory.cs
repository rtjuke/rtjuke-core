using RTJuke.Core.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTJuke.Core.Services
{
    /// <summary>
    /// Service to access / manage the play history
    /// </summary>
    public interface IPlayHistory
    {
        void Begin();

        void End();

        /// <summary>
        /// Signal that the given song has just been played
        /// </summary>
        /// <param name="song"></param>
        /// <returns></returns>
        Task Add(Song song);

        /// <summary>
        /// Return whether this song was played already
        /// </summary>        
        bool WasPlayedAlready(Song song);
    }

    /// <summary>
    /// An entry of the play history
    /// </summary>
    public interface IPlayHistoryEntry
    {
        DateTime Timestamp { get; }

        string ProviderId { get; }

        string Filename { get; }
    }
}
