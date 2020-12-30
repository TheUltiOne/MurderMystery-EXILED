using System;
using System.Linq;

using Exiled.Permissions.Extensions;

using CommandSystem;
using RemoteAdmin;

using EPlayer = Exiled.API.Features.Player;

namespace MurderMystery
{
    [CommandHandler(typeof(ClientCommandHandler))]
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
                    EPlayer pplayer = EPlayer.Get(player.SenderId);
                    if (Permissions.CheckPermission(sender, "murd.get"))
                    {
                        response = $"The murderer is {Handlers.Server.intruders.FirstOrDefault().Nickname}.";
                        return true;
                    }
                }
                response = "Use from the game console";
                return false;
            }
        }
    }
}
