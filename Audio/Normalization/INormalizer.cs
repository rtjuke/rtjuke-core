using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RTJuke.Core.Audio.Normalization
{
    public interface INormalizer
    {

        NormalizationInfo GetNormalizationInfo(String filename);

        /// <summary>
        /// Gets called when playing a BASS stream and normalization of a sample is required
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="channel"></param>
        /// <param name="buffer"></param>
        /// <param name="length"></param>
        /// <param name="peak"></param>
        void NormalizeSample(NormalizationInfo normalizationInfo, int handle, int channel, IntPtr buffer, int length, IntPtr peak);

    }
}
