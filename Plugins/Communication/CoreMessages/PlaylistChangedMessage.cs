using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTJuke.Core.Plugins.Communication.CoreMessages
{
    /// <summary>
    /// Message which is published when the current playlist / coming up song changes
    /// </summary>
    public class PlaylistChangedMessage : IPluginMessage
    {
        public static readonly Guid Id = new Guid("{C1E7EF31-0E68-49E8-BDF4-6C951EFF46EA}");        

        public Guid MessageId
        {
            get { return Id; }
        }        
    }
}
