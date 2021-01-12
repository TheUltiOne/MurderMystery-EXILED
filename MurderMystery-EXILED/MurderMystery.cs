using Exiled.API.Features;
using Exiled.API.Enums;

using Server = Exiled.Events.Handlers.Server;
using Player = Exiled.Events.Handlers.Player;
using Map = Exiled.Events.Handlers.Map;

using System;

namespace MurderMystery
{
    public class MurderMystery : Plugin<Config>
    {
        private static readonly Lazy<MurderMystery> LazyInstance = new Lazy<MurderMystery>(valueFactory: () => new MurderMystery());
        public static MurderMystery Instance => LazyInstance.Value;

        public override PluginPriority Priority { get; } = PluginPriority.Medium;

        private Handlers.Server server;
        private Handlers.Player player;
        private Handlers.Map map;

        private MurderMystery()
        {
        }

        public override void OnEnabled()
        {
            RegisterEvents();
        }

        public override void OnDisabled()
        {
            UnregisterEvents();
        }

        public void RegisterEvents()
        {
            player = new Handlers.Player();
            server = new Handlers.Server();
            map = new Handlers.Map();

            Player.Hurting += player.OnHurting;
            Player.Died += player.OnDied;
            Player.Dying += player.OnDying;

            Server.RoundStarted += server.OnRoundStarted;
            Server.RespawningTeam += server.Respawning;
            Server.EndingRound += server.OnEndingRound;

            Map.Decontaminating += map.OnDecontaminating;
        }

        public void UnregisterEvents()
        {


            Player.Hurting -= player.OnHurting;
            Player.Died -= player.OnDied;
            Player.Dying -= player.OnDying;
            player = null;

            Server.RoundStarted -= server.OnRoundStarted;
            Server.RespawningTeam -= server.Respawning;
            Server.EndingRound -= server.OnEndingRound;
            server = null;

            Map.Decontaminating -= map.OnDecontaminating;
            map = null;
        }
    }
}
