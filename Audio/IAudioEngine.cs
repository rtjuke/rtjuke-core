using RTJuke.Core.Audio;
using RTJuke.Core.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTJuke.Core.Audio
{
    /// <summary>
    /// Interface for classes which provide instanciation of IAudioFiles
    /// </summary>
    public interface IAudioEngine : IPlugin
    {
        IAudioFile GetAudioFile(string uri);
    }
}
