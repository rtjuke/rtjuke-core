using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RTJuke.Core.ViewModels;
using RTJuke.Core.Types;

namespace RTJuke.Core.Services
{
    /// <summary>
    /// Service to manipulate the playlist
    /// </summary>
    public interface IPlaylistService
    {
        /// <summary>
        /// Return the currently playing song
        /// </summary>
        /// <returns></returns>
        Song GetNowPlaying();

        /// <summary>
        /// Return the song which will be played next
        /// </summary>
        Song GetComingUp();

        /// <summary>
        /// Return the contents of the playlist
        /// </summary>
        IReadOnlyList<Song> GetCurrentlyEnqueued();

        void SaveCurrentSession();

        /// <summary>
        /// Enqueue the given song
        /// </summary>
        /// <param name="song"></param>
        void Enqueue(Song song);

        /// <summary>
        /// The song is put as coming up
        /// </summary>
        /// <param name="song"></param>
        void Quickplay(Song song);  
    }
}
