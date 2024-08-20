using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RTJuke.Core.Plugins
{
    public class PluginInfo
    {
        public PluginType Type { get; set; }

        /// <summary>
        /// Unique identifier of this plugin type
        /// </summary>
        public string Identifier { get; private set; }

        /// <summary>
        /// The name of this plugin
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// The class of this plugin
        /// </summary>
        public Type PluginClass { get; private set; }

        public Version Version { get; private set; }

        /// <summary>
        /// A description of this plugins functions
        /// </summary>
        public String Description { get; private set; }

        /// <summary>
        /// Define sif the plugin can be loaded multiple times or only once
        /// </summary>
        public bool MultipleInstancesAllowed { get; private set; }

        public PluginInfo(PluginType type, string identifier, string name, Type pluginClass, Version version, Boolean multipleInstancesAllowed, string description = "")
        {
            Type = type;
            Identifier = identifier;
            Name = name;
            PluginClass = pluginClass;
            Version = version;
            MultipleInstancesAllowed = multipleInstancesAllowed;

            Description = description;
        }
    }

    public enum PluginType
    {
        General = 0,        
        LibraryProvider = 1,
        Visualization = 2,
        Shuffler = 3,
        AlbumArtProvider = 4,
        AudioEngine = 5
    }
    
}
