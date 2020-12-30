using System.Linq;
using Exiled.API.Features;
using EPlayer = Exiled.API.Features.Player;
using Exiled.Events.EventArgs;
using EMap = Exiled.API.Features.Map;

namespace MurderMystery.Handlers
{
    class Player
    {
        public void OnHurting(HurtingEventArgs ev) {
            if (MurderMystery.Instance.Config.OneShotUSP == true)
            {
                if (ev.DamageType == DamageTypes.Usp)
                {
                    var config = MurderMystery.Instance.Config;
                    if (Server.intruders.Contains(ev.Target))
                    {
                        ev.Target.Kill(damageType: DamageTypes.Usp);
                    }
                    else if (ev.DamageType != DamageTypes.Usp && ev.DamageType != DamageTypes.Mp7)
                    {
                        ev.IsAllowed = false;
                        ev.Attacker.Broadcast(duration: 5, message: config.ComShootErrorMessage);
                    }
                    else if (!Server.intruders.Contains(ev.Attacker))
                    {
                        ev.IsAllowed = false;
                        if (config.DieBySCP049 == true)
                        {
                            ev.Attacker.Kill(damageType: DamageTypes.Scp049);
                        }
                        else
                        {
                            ev.Attacker.Kill(damageType: DamageTypes.Usp);
                        }
                        ev.Attacker.Broadcast(duration: 5, message: config.KillByInnocent);
                    }
                }
            }

        }

        public void OnDied(DiedEventArgs ev)
        {
            if (EPlayer.List.Where(x => x.Team != Team.RIP).Count() == 1) // This will be changed in future update
            {
                if (Server.intruders.Contains(EPlayer.List.Where(x => x.Team != Team.RIP).ElementAt(0))) // For later update
                {
                    EMap.Broadcast(duration: 5, message: $"The CI Intruder wins! [{ev.Killer.Nickname} was the CI Intruder]");
                    Server.RoundEndForced = true;
                    Server.CIWins = true;
                    Round.ForceEnd();

                } else
                {
                    EMap.Broadcast(duration: 5, message: $"{ev.Target.Nickname} was the CI Intruder and was killed! SCP Foundation wins!");
                    Server.RoundEndForced = true;
                    Server.CIWins = false;
                    Round.ForceEnd();
                }
            } else if (Server.intruders.Contains(ev.Target))
            {
                EMap.Broadcast(duration: 5, message: $"{ev.Target.Nickname} was the CI Intruder and was killed! SCP Foundation wins!");
                Server.RoundEndForced = true;
                Server.CIWins = false;
                Round.ForceEnd();
            }
        }

        public void OnDying(DyingEventArgs ev)
        {
            if (MurderMystery.Instance.Config.OneShotUSP == false) // for avoiding to run this code if oneshotusp = true
            {
                if (ev.HitInformation.GetDamageType() == DamageTypes.Usp)
                {
                    var config = MurderMystery.Instance.Config;
                    if (Server.intruders.Contains(ev.Target))
                    {
                        ev.Target.Kill(damageType: DamageTypes.Usp);
                    }
                    else if (ev.HitInformation.GetDamageType() == DamageTypes.Com15)
                    {
                        ev.IsAllowed = false;
                        ev.Killer.Broadcast(duration: 5, message: config.ComShootErrorMessage);
                    }
                    else if (!Server.intruders.Contains(ev.Killer))
                    {
                        ev.IsAllowed = false;
                        if (config.DieBySCP049 == true)
                        {
                            ev.Killer.Kill(damageType: DamageTypes.Scp049);
                        }
                        else
                        {
                            ev.Killer.Kill(damageType: DamageTypes.Usp);
                        }
                        ev.Killer.Broadcast(duration: 5, message: config.KillByInnocent);
                    }
                }
            }
        }
    }
}
