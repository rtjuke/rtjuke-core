using RTJuke.Core.Plugins;
using RTJuke.Core.Types;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTJuke.Core.Services
{
    public interface IPluginService
    {        
        IList<PluginInfo> AvailablePlugins { get; }        

        IList<LoadedPlugin> LoadedPlugins { get; }

        ObservableCollection<PluginCustomControl> RegisteredPluginControls { get; }

        void Init();

        void Shutdown();

        ILibraryProvider GetLibraryProvider(string providerId);

        LoadedPlugin InstantiatePlugin(PluginInfo pInfo, string providerId = null);        
    }
}
