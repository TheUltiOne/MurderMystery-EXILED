using System;
using System.Linq;

using Exiled.API.Features;
using Exiled.Permissions.Extensions;

using CommandSystem;

using RemoteAdmin;


namespace MurderMystery.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    class Disable : ICommand
    {

        public string Command => "disable";

        public string[] Aliases => Array.Empty<string>();

        public string Description => "Disables the gamemode";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            {
                if (sender is PlayerCommandSender player)
                {
                    Player pplayer = Player.Get(player.SenderId);
                    MurderMystery.Instance.OnDisabled();

                    response = "Disabled gamemode!";
                    return true;
                }
                response = "Use from the game console";
                return false;
            }
        }
    }
}
