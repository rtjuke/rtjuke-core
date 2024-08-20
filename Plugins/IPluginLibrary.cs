using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RTJuke.Core.Plugins
{
    /// <summary>
    /// Defines a class which enables to access
    /// RTJuke plugins contained in an assembly
    /// </summary>
    public interface IPluginLibrary
    {        
        IEnumerable<PluginInfo> GetContainedPlugins();
    }
}
