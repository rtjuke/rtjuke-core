using RTJuke.Core.Types;
using RTJuke.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTJuke.Core.Plugins.Communication.CoreMessages
{
    /// <summary>
    /// A message which is send by the main application when the playback state changes
    /// </summary>
    public class PlayerStateEventMessage : IPluginMessage
    {
        public static readonly Guid Id = new Guid("{81B7D095-25EF-4B50-9A90-165293E81F09}");

        /// <summary>
        /// The event which occured
        /// </summary>
        public PlayerStateEvent EventType { get; private set; }

        /// <summary>
        /// The song to which this event happened
        /// </summary>
        public ISongViewModel Song { get; private set; }

        public Guid MessageId
        {
            get { return Id; }
        }

        public PlayerStateEventMessage(PlayerStateEvent eventType, ISongViewModel song)
        {
            EventType = eventType;
            Song = song;
        }
    }

    public enum PlayerStateEvent
    {        
        NowPlayingSongChanged,
        Playing,
        Paused,
        Stopped
    }
}
