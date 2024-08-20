using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTJuke.Core.Plugins.Communication.CoreMessages
{
    public class PlayerCommandMessage : IPluginMessage
    {
        public static Guid Id = new Guid("{869A71EB-6130-4041-A919-553BD57464D5}");

        public Guid MessageId
        {
            get { return Id; }
        }

        public PlayerCommand Command { get; private set; }

        public PlayerCommandMessage(PlayerCommand command)
        {
            Command = command;
        }
    }

    public enum PlayerCommand
    {
        Play,
        Pause,
        TogglePlayPause,
        Next
    }
}
