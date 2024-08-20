using RTJuke.Core.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTJuke.Core.Plugins.Communication.CoreMessages
{
    /// <summary>
    /// Plugin message to request an audio stream (IAudioFile) for the given Uri from the core audio engine of RTJuke
    /// (Can be a local file or a web stream)
    /// </summary>
    public class RequestAudioStreamMessage : RequestMessage<AudioStreamResponseMessage>
    {
        public static Guid Id = Guid.Parse("{9F6EE44D-0FB0-4FDC-8DAC-A34ED3859D3A}");

        public override Guid MessageId
        {
            get { return Id; }
        }

        public string Uri { get; set; }

        public RequestAudioStreamMessage(string uri)
        {
            Uri = uri;
        }

        public override AudioStreamResponseMessage CreateResponse()
        {
            return new AudioStreamResponseMessage(FrameId, Uri, null);
        }

        public AudioStreamResponseMessage CreateResponse(string uri, IAudioFile stream)
        {
            return new AudioStreamResponseMessage(FrameId, uri, stream);
        }
    }

    /// <summary>
    /// Response message to a RequestAudioStreamMessage
    /// </summary>
    public class AudioStreamResponseMessage : ResponseMessage
    {
        public static Guid Id = Guid.Parse("{3E948546-5E20-4562-8328-984284AC7D74}");

        public override Guid MessageId
        {
            get { return Id; }
        }

        public string Uri { get; private set; }

        public IAudioFile Stream { get; private set; }

        internal AudioStreamResponseMessage(Guid responseTo)
            : this(responseTo, "", null)
        {
            // --
        }

        internal AudioStreamResponseMessage(Guid responseTo, string uri, IAudioFile stream)
            : base(responseTo)
        {
            Uri = uri;
            Stream = stream;
        }
    }
}
