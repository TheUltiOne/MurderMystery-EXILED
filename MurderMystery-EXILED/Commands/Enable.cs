﻿using System;
using System.Linq;

using Exiled.API.Features;
using Exiled.Permissions.Extensions;

using CommandSystem;

using RemoteAdmin;


namespace MurderMystery.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    class Enable : ICommand
    {

        public string Command => "enable";

        public string[] Aliases => Array.Empty<string>();

        public string Description => "Enables the gamemode";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            {
                /*
                if (sender is PlayerCommandSender player)
                {
                    Player pplayer = Player.Get(player.SenderId);
                    MurderMystery.Instance.OnEnabled();

                    response = "Enabled gamemode!";
                    return true;
                }
                */
                response = "This command is disabled because it crashes your server.";
                return false;
            }
        }
    }
}
