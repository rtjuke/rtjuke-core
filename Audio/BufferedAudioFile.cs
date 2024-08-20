using RTJuke.Core.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTJuke.Core.Audio
{
    /// <summary>
    /// A helper implementation of IAudioFile which
    /// uses a customizable asynchronous function to load
    /// the audio file
    /// </summary>
    public class BufferedAudioFile : IAudioFile
    {
        IAudioFile wrapped = null;

        Func<Task<IAudioFile>> streamFunc;

        PlayState state = PlayState.Opening;

        public PlayState CurrentState
        {
            get
            {
                return wrapped?.CurrentState ?? state;                
            }
            private set
            {
                if (wrapped == null)
                {
                    state = value;
                    OnPlayStateChanged();
                }
            }
        }

        TimeSpan? length = null;

        public TimeSpan? Length
        {
            get
            {
                return wrapped?.Length ?? length;                
            }
            private set
            {
                if (length != value)
                {
                    length = value;
                    OnLengthChanged();
                }
            }
        }

        public TimeSpan Position
        {
            get
            {
                return wrapped?.Position ?? TimeSpan.FromSeconds(0);                
            }
            set
            {
                if (wrapped != null)
                    wrapped.Position = value;
            }
        }

        int volume = 255;

        public int Volume
        {
            get
            {
                return wrapped?.Volume ?? volume;                
            }
            set
            {
                volume = value;

                if (wrapped != null)
                    wrapped.Volume = value;
            }
        }

        Song Song { get; set; }

        public double BufferProgress => wrapped?.BufferProgress ?? 0;

        public bool IsBuffering => wrapped?.IsBuffering ?? false;

        public event EventHandler PlayStateChanged;
        public event EventHandler PositionChanged;
        public event EventHandler LengthChanged;
        public event EventHandler BufferStateChanged;

        public BufferedAudioFile(Func<Task<IAudioFile>> streamFunc, Song song)
        {
            this.streamFunc = streamFunc;
            Song = song;

            length = song.Length;
        }

        private void SignalError()
        {
            state = PlayState.Error;
            OnPlayStateChanged();
        }

        public async Task<bool> LoadAsync()
        {
            wrapped = await streamFunc();

            wrapped.Volume = volume;
            if (length.HasValue)
                wrapped.SetKnownLength(length.Value);

            wrapped.PositionChanged += PositionChanged_Handler;
            wrapped.PlayStateChanged += PlayStateChanged_Handler;
            wrapped.LengthChanged += LengthChanged_Handler;
            wrapped.BufferStateChanged += BufferProgressChanged_Handler;

            bool result = await wrapped.LoadAsync();
            OnPlayStateChanged();
            return result;
        }

        public void Close()
        {
            if (wrapped != null)
            {
                // unregister event handlers
                wrapped.PositionChanged -= PositionChanged_Handler;
                wrapped.PlayStateChanged -= PlayStateChanged_Handler;
                wrapped.LengthChanged -= LengthChanged_Handler;
                wrapped.BufferStateChanged -= BufferProgressChanged_Handler;

                wrapped.Close();
            }                
        }

        public void Dispose()
        {
            Close();
        }

        public void FadeIn(int milliseconds)
        {
            if (wrapped != null)
                wrapped.FadeIn(milliseconds);
        }

        public void FadeOut(int milliseconds)
        {
            if (wrapped != null)
                wrapped.FadeOut(milliseconds);
        }

        public bool GetFftData(float[] fftResultBuffer)
        {
            if (wrapped != null)
                return wrapped.GetFftData(fftResultBuffer);
            else
                return false;
        }

        public int GetSampleRate()
        {
            if (wrapped != null)
                return wrapped.GetSampleRate();
            else
                return 0;
        }

        public void Pause()
        {
            if (wrapped != null)
                wrapped.Pause();
        }

        public void Play()
        {
            if (wrapped != null)
                wrapped.Play();
        }

        public async Task<AudioTags> ReadTags()
        {
            if (wrapped == null)
            {
                if (!await LoadAsync())
                    return null;
            }

            return await wrapped.ReadTags();
        }

        public void SetKnownLength(TimeSpan tSpan)
        {
            if (wrapped != null)
                wrapped.SetKnownLength(tSpan);

            Length = tSpan;
        }

        public void Stop()
        {
            if (wrapped != null)
                wrapped.Stop();
        }

        public bool SupportsFft(out int numBands)
        {
            if (wrapped != null)
                return wrapped.SupportsFft(out numBands);
            else
            {
                numBands = 0;
                return false;
            }
        }

        #region Event pass-through

        protected void PlayStateChanged_Handler(object sender, EventArgs e)
        {
            OnPlayStateChanged();
        }

        protected void PositionChanged_Handler(object sender, EventArgs e)
        {
            OnPositionChanged();
        }

        protected void LengthChanged_Handler(object sender, EventArgs e)
        {
            length = wrapped.Length;
            OnLengthChanged();
        }

        protected void BufferProgressChanged_Handler(object sender, EventArgs e)
        {            
            OnBufferProgressChanged();
        }

        protected void OnPlayStateChanged()
        {
            var pc = PlayStateChanged;
            if (pc != null)
                pc(this, EventArgs.Empty);
        }

        protected void OnPositionChanged()
        {
            var pc = PositionChanged;
            if (pc != null)
                pc(this, EventArgs.Empty);
        }

        protected void OnLengthChanged()
        {
            var pc = LengthChanged;
            if (pc != null)
                pc(this, EventArgs.Empty);
        }

        protected void OnBufferProgressChanged()
        {
            var eh = BufferStateChanged;
            if (eh != null)
                eh(this, EventArgs.Empty);
        }

        #endregion
    }
}
