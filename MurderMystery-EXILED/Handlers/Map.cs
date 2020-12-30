using System.Linq;
using Exiled.API.Features;
using EPlayer = Exiled.API.Features.Player;
using Exiled.Events.EventArgs;

namespace MurderMystery.Handlers
{
    class Map
    {
        public void OnDecontaminating(DecontaminatingEventArgs ev)
        {
            if (MurderMystery.Instance.Config.IntruderLoseByDecontamination == true)
            {
                Server.intruders.ElementAt(0).Kill(damageType: DamageTypes.Asphyxiation);
            }
            else
            {
                foreach (EPlayer bystander in Server.bystanders)
                {
                    bystander.Kill(damageType: DamageTypes.Asphyxiation);
                }
                foreach (EPlayer scout in Server.scouts)
                {
                    scout.Kill(damageType: DamageTypes.Asphyxiation);
                }
            }
        }
    }
}
