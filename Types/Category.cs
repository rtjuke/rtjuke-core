using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RTJuke.Core.Types
{
    /// <summary>
    /// A custom keyword (tag) given to a song
    /// </summary>
    public class Keyword
    {

        public Keyword(String category, String name)
        {
            Category = category ?? throw new ArgumentNullException(nameof(category));
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        /// <summary>
        /// Category of the keyword (e.g. genre, mood, ...)
        /// </summary>
        public String Category { get; private set; }

        /// <summary>
        /// Name of the keyword
        /// </summary>
        public String Name { get; private set; }

        public override bool Equals(object obj)
        {
            if (obj is Keyword)
            {
                if (obj == this)
                    return true;

                return this.Category == ((Keyword)obj).Category && this.Name == ((Keyword)obj).Name;
            }
            else
            {
                return base.Equals(obj);
            }
        }

        public override int GetHashCode()
        {
            return Category.GetHashCode() ^ Name.GetHashCode();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
