using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTJuke.Core.Library
{
    /// <summary>
    /// 
    /// </summary>
    public interface ILibrarySerializer
    {        
        void Write(IMusicLibrary musicLibrary);        

    }
}
