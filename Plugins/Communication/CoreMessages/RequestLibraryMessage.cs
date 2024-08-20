using RTJuke.Core.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTJuke.Core.Plugins.Communication.CoreMessages
{
    public class RequestLibraryMessage : RequestMessage<LibraryResponseMessage>
    {
        public static Guid Id = new Guid("{36F00BDE-D86E-4927-A3E5-B10EE75600D5}");

        public override Guid MessageId
        {
            get { return Id; }
        }

        public override LibraryResponseMessage CreateResponse()
        {
            return new LibraryResponseMessage(FrameId, null);
        }

        public LibraryResponseMessage CreateResponse(IMusicLibrary library)
        {
            return new LibraryResponseMessage(FrameId, library);
        }
    }

    public class LibraryResponseMessage : ResponseMessage
    {
        public static Guid Id = Guid.Parse("{A6B848F9-C2F5-4EE0-B274-B2907D649B86}");

        public override Guid MessageId
        {
            get { return Id; }
        }

        public IMusicLibrary Library { get; private set; }

        internal LibraryResponseMessage(Guid responseTo, IMusicLibrary library)
            : base(responseTo)
        {
            Library = library;
        }
    }
}
