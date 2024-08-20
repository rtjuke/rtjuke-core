using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RTJuke.Core.Audio.Normalization
{
    public abstract class NormalizationInfo
    {

        public abstract NormalizationType Type { get; }

        public abstract String Serialize();        
        public abstract void Deserialize(String s);

    }
}
