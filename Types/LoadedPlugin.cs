using RTJuke.Core.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTJuke.Core.Types
{
    public class LoadedPlugin
    {
        /// <summary>
        /// The unique Id of this plugin instance (can be a Guid)
        /// </summary>
        public String ProviderId { get; private set; }

        /// <summary>
        /// The plugin type
        /// </summary>
        public PluginType Type
        {
            get
            {
                return PluginInfo.Type;
            }
        }

        public PluginInfo PluginInfo { get; private set; }

        public IPlugin Instance { get; private set; }

        public T GetInstance<T>()
            where T: IPlugin
        {
            if (Instance is T)
                return (T)Instance;
            else
                throw new ArgumentException("The plugin is not of the requested type.");
        }

        public LoadedPlugin(PluginInfo pluginInfo, string providerId, IPlugin instance)
        {
            PluginInfo = pluginInfo;
            ProviderId = providerId;
            Instance = instance;
        }
    }
}
