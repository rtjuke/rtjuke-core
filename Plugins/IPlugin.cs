using RTJuke.Core.Plugins.Communication;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTJuke.Core.Plugins
{
    /// <summary>
    /// Base interface for RTJuke plugins
    /// </summary>
    public interface IPlugin
    {
        /// <summary>
        /// Return a text string which describes the (basic) settings
        /// of this plugin in a human-friendly form
        /// </summary>
        string HumanFriendlySettingsText { get; }

        /// <summary>
        /// Called for teh plugin to initialize its resources etc.
        /// <param name="messageBus">The message bus which can be used to communicate with the main application or other plugins</param>
        /// </summary>
        void Init(IMessageBus messageBus);

        /// <summary>
        /// Called when the application is ready and the plugin may start its function
        /// </summary>
        void Start();

        /// <summary>
        /// Sets the culture info which should be used by this plugin,
        /// if an unsupported language is passed the plugin should fallback
        /// to en(-us)
        /// </summary>
        /// <param name="cultureInfo"></param>
        void SetLocalization(CultureInfo cultureInfo);

        /// <summary>
        /// Called when the plugin should be deinitialized
        /// The plugin instance will not be used again thereafter
        /// The plugin should deregister all message handlers
        /// </summary>
        void Shutdown();

        /// <summary>
        /// Show a dialog to configure this plugin
        /// </summary>
        /// <returns>true, if the settings have been changed</returns>
        bool Configure();

        /// <summary>
        /// Return if this plugin supports configuration
        /// </summary>
        /// <returns></returns>
        bool CanBeConfigured();

        /// <summary>
        /// Retrieve the settings of this provider as string
        /// which is then saved in the application settings
        /// </summary>        
        String GetSettings();

        /// <summary>
        /// Restore the settings stored in a settings string previously
        /// retrieved through the GetSettings() method
        /// </summary>        
        /// <returns>true, if the action was successful</returns>
        bool SetSettings(String settingsStr);
    }
}
