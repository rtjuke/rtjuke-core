using RTJuke.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTJuke.Core.Plugins.Communication.CoreMessages
{
    public class RequestPlaylistMessage : RequestMessage<PlaylistResponseMessage>
    {
        public static Guid Id = new Guid("{320D65E7-6D24-43B6-9342-6E37E6082CC6}");

        public override Guid MessageId
        {
            get { return Id; }
        }

        public override PlaylistResponseMessage CreateResponse()
        {
            return new PlaylistResponseMessage(FrameId, null);
        }

        public PlaylistResponseMessage CreateResponse(IPlaylistService playlistService)
        {
            return new PlaylistResponseMessage(FrameId, playlistService);
        }
    }

    public class PlaylistResponseMessage : ResponseMessage
    {
        public static Guid Id = Guid.Parse("{EF35E871-51F1-41A8-BC3D-690E20D25E2E}");

        public override Guid MessageId
        {
            get { return Id; }
        }

        public IPlaylistService PlaylistService { get; private set; }

        internal PlaylistResponseMessage(Guid responseTo, IPlaylistService playlistService)
            : base(responseTo)
        {
            PlaylistService = playlistService;
        }
    }
}
