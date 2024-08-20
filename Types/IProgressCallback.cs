using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTJuke.Core.Types
{
    public interface IProgressCallback
    {
        bool IsIndeterminate { get; set; }
        string CurrentStepDescription { get; set; }
        int CurrentStepProgress { get; set; }
        int CurrentStepMaximum { get; set; }
    }
}
