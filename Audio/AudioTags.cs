using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTJuke.Core.Audio
{
    /// <summary>
    /// Represents the tags of an audio file
    /// </summary>
    public class AudioTags
    {
        public string Track { get; set; }
        public string Title { get; set; }
        public string Album { get; set; }
        public string Artist { get; set; }

        List<String> genres = new List<string>();

        public TimeSpan Length { get; set; }

        public IList<String> Genres
        {
            get
            {
                return genres;
            }
        }
    }
}
