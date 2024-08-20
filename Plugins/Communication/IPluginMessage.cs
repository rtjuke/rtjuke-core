using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTJuke.Core.Plugins.Communication
{
    /// <summary>
    /// Interface for messages which may be send to or from plugins
    /// </summary>
    public interface IPluginMessage
    {
        /// <summary>
        /// The unique type ID of this message
        /// </summary>
         Guid MessageId { get; }        
    }

    /// <summary>
    /// Base class for messages which require a response
    /// </summary>
    public abstract class RequestMessage<ResponseType> : IPluginMessage
        where ResponseType: ResponseMessage
    {
        public abstract Guid MessageId { get; } 
        /// <summary>
        /// Id to identify the response
        /// </summary>
        public Guid FrameId { get; private set; }

        public RequestMessage()
        {
            FrameId = Guid.NewGuid();
        }

        /// <summary>
        /// Creates the correct response message for this request message
        /// </summary>
        /// <returns></returns>
        public abstract ResponseType CreateResponse();
    }

    /// <summary>
    /// Base class for response messages 
    /// </summary>
    public abstract class ResponseMessage : IPluginMessage
    {
        public abstract Guid MessageId { get;  } 

        /// <summary>
        /// Id to identify the response
        /// </summary>
        public Guid ResponseToFrameId { get; private set; }

        internal ResponseMessage(Guid responseTo)
        {
            ResponseToFrameId = responseTo;
        }
    }
}
