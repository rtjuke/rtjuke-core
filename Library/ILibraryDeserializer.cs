using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTJuke.Core.Library
{
    public interface ILibraryDeserializer
    {
        void Read(IMusicLibrary musicLibrary);        
    }
}
