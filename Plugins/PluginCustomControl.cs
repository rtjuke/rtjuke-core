using RTJuke.Core.Plugins.Communication.UIMessages;
using RTJuke.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RTJuke.Core.Plugins
{
    /// <summary>
    /// Matches a custom ui control with its owner plugin
    /// </summary>
    public class PluginCustomControl
    {
        public IPlugin Owner { get; set; }
        public ControlAnchor Anchor { get; set; }        
        public string ControlId { get; set; }
        public object Control { get; set; }
    }
}
