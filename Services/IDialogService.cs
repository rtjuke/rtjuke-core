using RTJuke.Core.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTJuke.Core.Services
{
    public interface IDialogService
    {
        void ShowMusicLibrary();

        bool ShowOpenFileDialog(out String[] selectedFiles);

        void ShowSettingsDialog();

        /// <summary>
        /// SHows a yes/no prompt
        /// </summary>
        /// <param name="question"></param>
        /// <returns>true if yes was clicked otherwise false</returns>
        bool ShowYesNoPrompt(string question);

        void ShowInformationMessage(string message);

        void ShowUpdateDialog();
    }
}
