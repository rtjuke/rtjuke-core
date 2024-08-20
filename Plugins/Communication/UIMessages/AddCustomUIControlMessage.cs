using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RTJuke.Core.Plugins.Communication.UIMessages
{
    /// <summary>
    /// Allows a plugin to add a custom control to the RTJuke UI
    /// </summary>
    public class AddCustomUIControlMessage : RequestMessage<AddCustomUIControlResponseMessage>
    {
        public static Guid Id = Guid.Parse("{8D7BED27-BD59-4BF7-96D8-9E070387B731}");

        public override Guid MessageId { get { return Id; } }

        public ControlAnchor Anchor { get; private set; }
        public object FrameworkControl { get; private set; }

        public AddCustomUIControlMessage(ControlAnchor anchor, object frameworkControl)
        {
            Anchor = anchor;
            FrameworkControl = frameworkControl;
        }

        public override AddCustomUIControlResponseMessage CreateResponse()
        {
            return CreateResponse(String.Empty);            
        }

        /// <summary>
        /// Create a succesful response message to this request
        /// </summary>
        /// <param name="controlId">Id to identify this control in this session (used to modify the contro later)</param>
        /// <returns></returns>
        public AddCustomUIControlResponseMessage CreateResponse(string controlId)
        {
            return new AddCustomUIControlResponseMessage(FrameId, controlId);
        }
    }

    public class AddCustomUIControlResponseMessage : ResponseMessage
    {
        public static Guid Id = Guid.Parse("{4BF69CCF-06B1-476E-8F18-5B32B2A79100}");

        public override Guid MessageId { get { return Id; } }        

        public String AssignedControlId { get; private set; }

        public AddCustomUIControlResponseMessage(Guid responseTo, String controlId)
            : base( responseTo)
        {
            AssignedControlId = controlId;
        }
    }

    /// <summary>
    /// Available anchors for custom ui controls
    /// </summary>
    public enum ControlAnchor
    {
        /// <summary>
        /// Top of the RTJuke window
        /// </summary>
        Top,        
        /// <summary>
        /// Above the playlist
        /// </summary>
        AbovePlaylist,
        /// <summary>
        /// Below the playlist
        /// </summary>
        BelowPlaylist,
        /// <summary>
        /// The default place for visualizers
        /// </summary>
        DefaultVisualizationPane
    }
}
