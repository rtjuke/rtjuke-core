using RTJuke.Core.Audio;
using RTJuke.Core.Types;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace RTJuke.Core.ViewModels
{
    public interface ISongViewModel
    {
        public Song Model { get; }

        public IAudioFile AudioFile { get; }

        public string Title { get; }

        public string Album { get; }

        public string Artist { get; }

        public string Track { get; }

        public HashSet<Keyword> Keywords { get; }

        public TimeSpan? Length { get; }        

        public PlayState CurrentState { get; }

        public Uri Cover { get; }

        public ICommand PlayPauseCommand { get; }
        public ICommand StopCommand { get; }
    }
}
