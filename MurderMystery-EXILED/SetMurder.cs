using System;
using System.Linq;

using Exiled.Permissions.Extensions;

using CommandSystem;

using RemoteAdmin;

using EPlayer = Exiled.API.Features.Player;

namespace MurderMystery
{
    [CommandHandler(typeof(ClientCommandHandler))]
    class SetMurder : ICommand
    {

        public string Command => "setmurderer";

        public string[] Aliases => Array.Empty<string>();

        public string Description => "Sets the murderer";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            {
                if (sender is PlayerCommandSender player)
                {
                    EPlayer pplayer = EPlayer.Get(player.SenderId);
                    if (Permissions.CheckPermission(sender, "murd.set"))
                    {
                        var old = Handlers.Server.intruders.FirstOrDefault();
                        old.Broadcast(3, "You've been set to an innocent!");
                        old.ClearInventory();
                        Handlers.Server.bystanders.Add(old);
                        Handlers.Server.intruders.Clear();
                        old.Inventory.AddNewItem(ItemType.GunUSP, s: 0, b: 0, o: 0);
                        Handlers.Server.intruders.Add(EPlayer.Get(arguments.ElementAt(0)));

                        response = "Okay big gay";
                        return true;
                    }
                }
                response = "Use from the game console";
                return false;
            }
        }
    }
}
