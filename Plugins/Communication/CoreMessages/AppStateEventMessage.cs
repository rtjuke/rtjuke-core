using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTJuke.Core.Plugins.Communication.CoreMessages
{
    /// <summary>
    /// Sent when the application state changes
    /// </summary>
    public class AppStateEventMessage : IPluginMessage
    {
        public static Guid Id = new Guid("{1E80C77C-2595-4210-A727-6E29CCC35213}");

        public Guid MessageId
        {
            get { return Id; }
        }

        /// <summary>
        /// The event which occured
        /// </summary>
        public AppEvent AppEvent { get; private set; }

        public AppStateEventMessage(AppEvent appEvent)
        {
            AppEvent = appEvent;
        }
    }

    public enum AppEvent
    {
        /// <summary>
        /// The application was started
        /// </summary>
        Started,
        /// <summary>
        /// The application launched and is ready to use by the user
        /// </summary>
        Launched,

        Minimized,
        Restored,
        Maximized,

        /// <summary>
        /// Application main window was deactivated
        /// </summary>
        Deactivated,

        /// <summary>
        /// Application main window was activated
        /// </summary>
        Activated,

        /// <summary>
        /// The application is terminating
        /// </summary>
        Closing
    }
}
