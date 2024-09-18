using RTJuke.Core.Audio.Normalization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTJuke.Core.Audio
{
    /// <summary>
    /// Encapsulates an audio buffer
    /// </summary>
    public interface IAudioFile : IDisposable
    {        

        /// <summary>
        /// The current play state
        /// </summary>
        PlayState CurrentState { get; }

        /// <summary>
        /// Die Lautstärke 0 - 255
        /// </summary>
        int Volume { get; set; }

        /// <summary>
        /// The current stream position
        /// </summary>
        TimeSpan Position { get; set; }

        /// <summary>
        /// The stream is buffering (e.g. file is being downloaded in the background)
        /// </summary>
        bool IsBuffering { get; }

        /// <summary>
        /// The current buffer progress, if buffering in the range [0,1]
        /// </summary>
        double BufferProgress { get; }

        /// <summary>
        /// The stream length
        /// If null then the length is unknown
        /// </summary>
        TimeSpan? Length { get; }             

        /// <summary>
        /// Load the audio data into memory and
        /// prepare the audio file to be played (asynchronously)
        /// (signal completion by switching CurrentState to Ready and returning true)
        /// </summary>
        Task<bool> LoadAsync();

        /// <summary>
        /// Can be used to set the length of the audio file before it is loaded
        /// </summary>
        /// <param name="tSpan"></param>
        void SetKnownLength(TimeSpan tSpan);        

        /// <summary>
        /// Start playing
        /// </summary>
        void Play();

        /// <summary>
        /// Pause the playback
        /// </summary>
        void Pause();

        /// <summary>
        /// Stop playback and go back to position zero
        /// </summary>
        void Stop();

        /// <summary>
        /// Close the underlying stream
        /// </summary>
        void Close();

        /// <summary>
        /// Fade the volume from 0 to the current value of the Volume property
        /// </summary>        
        void FadeIn(int milliseconds);

        /// <summary>
        /// Fade the volume from the current value to 0
        /// </summary>        
        void FadeOut(int milliseconds);

        /// <summary>
        /// Get the audio tags from this file
        /// </summary>        
        Task<AudioTags> ReadTags();


        #region Visualization methods (fast-fourier transformation)

        /// <summary>
        /// Reurns if fft is supported and how many bands are generated
        /// </summary>
        /// <param name="numBands"></param>
        /// <returns></returns>
        bool SupportsFft(out int numBands);

        /// <summary>
        /// Return the sample rate of this song
        /// </summary>
        /// <returns></returns>
        int GetSampleRate();

        /// <summary>
        /// Return the fft data of the current position
        /// (fftResultBuffer must have the size of numBands retrieved from SupportsFft())
        /// </summary>
        /// <param name="fftResultBuffer"></param>
        /// <returns></returns>
        bool GetFftData(float[] fftResultBuffer);

        #endregion

        #region Events 

        /// <summary>
        /// Raised when the stream position has been changed
        /// (Constantly raised when playing)
        /// </summary>
        event EventHandler PositionChanged;

        /// <summary>
        /// Raised when the length of the stream changes or becomes available
        /// </summary>
        event EventHandler LengthChanged;

        /// <summary>
        /// Raised when the playback state changed
        /// </summary>
        event EventHandler PlayStateChanged;

        /// <summary>
        /// Raised when the buffer progress or the IsBuffering property changes
        /// </summary>
        event EventHandler BufferStateChanged;

        /// <summary>
        /// Raised when the fading in or out has finished
        /// </summary>
        event EventHandler FadeEnded;

        #endregion
    }

    public enum PlayState
    {
        Unknown,
        /// <summary>
        /// The stream is closed
        /// </summary>
        Closed,
        /// <summary>
        /// The stream is being opened and cannot be played yet
        /// </summary>
        Opening,
        /// <summary>
        /// The stream has been opened and can be played (but it still ma ybe buffering)
        /// </summary>
        ReadyToPlay,        
        Playing,
        Paused,
        Stopped,
        /// <summary>
        /// The stream reached the end
        /// </summary>
        Ended,
        Error        
    }
}
