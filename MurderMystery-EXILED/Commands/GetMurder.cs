using System;
using System.Linq;

using Exiled.Permissions.Extensions;

using CommandSystem;
using RemoteAdmin;

using Exiled.API.Features;

namespace MurderMystery.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    class GetMurderer : ICommand
    {

        public string Command => "getmurderer";

        public string[] Aliases => Array.Empty<string>();

        public string Description => "Gets the murderer";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            {
                if (sender is PlayerCommandSender player)
                {
                    Player pplayer = Player.Get(player.SenderId);

                    response = $"The murderer is {Handlers.Server.intruders.FirstOrDefault().Nickname}.";
                    return true;
                }
                response = "Use from the game console";
                return false;
            }
        }
    }
}
