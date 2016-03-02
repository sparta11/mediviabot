using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediviaBot.addresses
{
    interface GameAddress
    {

        uint GetLocalPlayerAddress();
        uint GetAttackingCreatureAddress();
        uint GetFollowingCreatureAddress();
        uint GetContainerStartAddress();

        uint GetPingAddress();
        uint GetCharacterNameAddress();
        uint GetIsOnlineAddress();

    }
}
