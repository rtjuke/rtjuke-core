using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RTJuke.Core.Plugins.Communication;
using System.Windows;
using RTJuke.Core.Audio;

namespace RTJuke.Core.Plugins
{
    /// <summary>
    /// A plugin which visualizes music
    /// </summary>
    public interface IVisualizer : IPlugin
    {
        /// <summary>
        /// Update the visualization using fft data from the given audio file
        /// </summary>
        /// <param name="audioFile"></param>
        void Update(IAudioFile audioFile);
    }
}
