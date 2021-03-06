using NitroxClient.Communication.Abstract;
using NitroxClient.Communication.Packets.Processors.Abstract;
using NitroxClient.MonoBehaviours;
using NitroxClient.Unity.Helper;
using NitroxModel.Packets;
using UnityEngine;

namespace NitroxClient.Communication.Packets.Processors
{
    public class GhostCrafterItemPickupProcessor : ClientPacketProcessor<GhostCrafterItemPickup>
    {
        private readonly IPacketSender packetSender;

        public GhostCrafterItemPickupProcessor(IPacketSender packetSender)
        {
            this.packetSender = packetSender;
        }

        public override void Process(GhostCrafterItemPickup packet)
        {
            GameObject gameObject = NitroxEntity.RequireObjectFrom(packet.GhostCrafterId);
            CrafterLogic crafterLogic = gameObject.RequireComponentInChildren<CrafterLogic>(true);

            if (crafterLogic.numCrafted > 0)
            {
                crafterLogic.numCrafted--;

                if (crafterLogic.numCrafted == 0)
                {
                    crafterLogic.Reset();
                }
            }
        }
    }
}
