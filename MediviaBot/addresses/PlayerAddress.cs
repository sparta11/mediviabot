using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediviaBot.addresses
{
    interface PlayerAddress
    {

        uint GetPlayerStartAddress();

        uint GetXPosAddress();
        uint GetYPosAddress();
        uint GetZPosAddress();

        uint GetIdAddress();
        uint GetNameAddress();
        uint GetDirectionAddress();
        uint GetHealthAddress();
        uint GetMaxHealthAddress();
        uint GetCapacityAddress();

        uint GetManaAddress();
        uint GetMaxManaAddress();

        uint GetLightAddress();

        uint GetInventoryHelmetAddress();
        uint GetInventoryNeckAddress();
        uint GetInventoryBackAddress();
        uint GetInventoryArmorAddress();
        uint GetInventoryRightHandAddress();
        uint GetInventoryLeftHandAddress();
        uint GetInventoryLegsAddress();
        uint GetInventoryFeetAddress();
        uint GetInventoryRingAddress();
        uint GetInventoryBeltAddress();

    }
}
